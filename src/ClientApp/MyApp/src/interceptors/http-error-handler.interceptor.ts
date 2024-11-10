import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { inject } from '@angular/core';
import { GlobalErrorHandler } from './global-error-handler';

export const httpErrorHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  const globalErrorHandler = inject(GlobalErrorHandler);
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      globalErrorHandler.handleError(error);
      return throwError(() => error);
    })
  );
};
