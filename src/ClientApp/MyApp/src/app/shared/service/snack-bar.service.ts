import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarConfig } from '../../../constants/SnackBarConfig';

@Injectable({
  providedIn: 'root',
})
export class SnackBarService {
  constructor(private readonly _snackBar: MatSnackBar) {}

  public open(message: string): void {
    this._snackBar.open(message, undefined, SnackBarConfig);
  }
}
