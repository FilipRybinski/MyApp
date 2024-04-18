import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrl: './login-dialog.component.scss',
})
export class LoginDialogComponent {
  constructor(private dialogRef: MatDialogRef<LoginDialogComponent>) {}

  closeLoginDialog(): void {
    this.dialogRef.close();
  }
}
