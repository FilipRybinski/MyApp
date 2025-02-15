import { Injectable, inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as Alerts from '../../app/shared/components/alerts';

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  private readonly snackBar = inject(MatSnackBar);

  private readonly WORK_IN_PROGRESS = 'WorkInProgress';

  public handleSuccess(message: string) {
    this.snackBar.openFromComponent(Alerts.AlertSuccessComponent, {
      data: message,
    });
  }

  public handleError(message: string) {
    this.snackBar.openFromComponent(Alerts.AlertErrorComponent, {
      data: message,
    });
  }

  public handleWorkInProgress() {
    this.snackBar.openFromComponent(Alerts.AlertWarningComponent, {
      data: this.WORK_IN_PROGRESS,
    });
  }
}
