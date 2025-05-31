import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { TranslatePipe } from '@ngx-translate/core';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-sidebar-theme-tool',
  imports: [CommonModule, MatIcon, TranslatePipe, MatTooltip],
  template: `
    <button
      mat-icon-button
      matTooltip="{{ 'Theme' | translate }}"
      (click)="toggleTheme()"
    >
      <mat-icon>light_mode</mat-icon>
    </button>
  `,
})
export class SidebarThemeToolComponent {
  public toggleTheme(): void {
    console.log('Toggle theme');
  }
}
