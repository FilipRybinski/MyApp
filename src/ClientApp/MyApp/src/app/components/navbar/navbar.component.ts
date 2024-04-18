import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from '../../dialogs/login-dialog/login-dialog.component';
import { MatDialogSize } from '../../../constants/MatDialogSize';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  constructor(private dialog: MatDialog) {}

  openLoginDialog(): void {
    this.dialog.open<LoginDialogComponent>(LoginDialogComponent, {
      width: MatDialogSize.SMALL,
    });
  }

  protected readonly open = open;
}
