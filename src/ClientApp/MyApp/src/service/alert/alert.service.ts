import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import * as Alerts from '../../app/shared/components/alerts';

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  private readonly WORK_IN_PROGRESS = 'work in progress';
  private readonly DEFAULT_ERROR = 'unexpected error';
  private readonly REASON = 'reason';

  constructor(private snackBar: MatSnackBar) {}

  public handleSuccess(message: string) {
    this.snackBar.openFromComponent(Alerts.AlertSuccessComponent, {
      data: message,
    });
  }

  public handleError(error: HttpErrorResponse) {
    this.snackBar.openFromComponent(Alerts.AlertErrorComponent, {
      data: this.extractError(error),
    });
  }

  public handleWorkInProgress() {
    this.snackBar.openFromComponent(Alerts.AlertWarningComponent, {
      data: this.WORK_IN_PROGRESS,
    });
  }

  private extractError(errorResponse: HttpErrorResponse): string {
    const { error } = errorResponse;
    if (error[this.REASON]) {
      return error[this.REASON];
    }
    const {
      error: { errors },
    } = errorResponse;
    if (errors) {
      const firstError = Object.keys(errors)[0];
      return errors[firstError][0];
    }
    return this.DEFAULT_ERROR;
  }
}
