import { ErrorHandler, inject, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertService } from '../service/alert/alert.service';

const UNIVERSAL_ERROR = 'UniversalError';

@Injectable({
  providedIn: 'root',
})
export class GlobalErrorHandler implements ErrorHandler {
  private readonly alert = inject(AlertService);

  public handleError(error: Error | HttpErrorResponse) {
    if (error instanceof HttpErrorResponse) {
      this.alert.handleError(this.extractHttpError(error));
    } else {
      this.alert.handleError(UNIVERSAL_ERROR);
    }
  }

  private extractHttpError(errorResponse: HttpErrorResponse): string {
    const { status } = errorResponse;
    switch (status) {
      case 401:
        return 'UnauthorizedError';
      case 403:
        return 'ForbiddenError';
      case 404:
        return 'NotFoundError';
      case 500:
        return 'InternalServerError';
      case 502:
        return 'BadGatewayError';
      case 503:
        return 'ServiceUnavailableError';
      case 504:
        return 'TimeoutError';
      default:
        return 'UnexpectedError';
    }
  }
}
