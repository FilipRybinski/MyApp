import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { SnackBarConfig } from '../../../../constants/SnackBarConfig';

@Injectable()
export class AlertService {
  constructor(private snackBar: MatSnackBar) {}

  public handleSuccess(message: string) {
    this.snackBar.open(message, undefined, SnackBarConfig);
  }

  public handleError(error: HttpErrorResponse) {
    this.snackBar.open(this.extractError(error), undefined, SnackBarConfig);
  }

  private extractError(error: HttpErrorResponse): string {
    console.log(error);
    return 'tmp';
  }
}
