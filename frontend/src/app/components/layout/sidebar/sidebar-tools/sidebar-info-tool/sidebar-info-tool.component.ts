import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { TranslatePipe } from '@ngx-translate/core';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-sidebar-info-tool',
  imports: [CommonModule, MatIcon, TranslatePipe, MatTooltip],
  template: `
    <button mat-icon-button matTooltip="{{ 'Info' | translate }}">
      <mat-icon>info_outline</mat-icon>
    </button>
  `,
})
export class SidebarInfoToolComponent {}
