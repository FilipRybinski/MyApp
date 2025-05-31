import {
  Component,
  input,
  InputSignal,
  output,
  OutputEmitterRef,
} from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LogoComponent } from '../logo/logo.component';

@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButtonModule, MatIconModule, LogoComponent],
  template: `
    <mat-toolbar class="shadow-md flex flex-col justify-between">
      <button
        mat-icon-button
        (click)="isSidebarOpenChange.emit(!isSidebarOpen())"
      >
        <mat-icon>apps</mat-icon>
      </button>
      <app-logo />
    </mat-toolbar>
  `,
  styles: [
    `
      mat-toolbar {
        position: relative;
        z-index: 5;
      }
    `,
  ],
})
export class NavbarComponent {
  isSidebarOpen: InputSignal<boolean> = input.required<boolean>();
  isSidebarOpenChange: OutputEmitterRef<boolean> = output<boolean>();
}
