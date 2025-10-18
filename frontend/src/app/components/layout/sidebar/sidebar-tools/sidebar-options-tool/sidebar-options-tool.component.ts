import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { TranslatePipe } from '@ngx-translate/core';
import { MatTooltip } from '@angular/material/tooltip';

@Component({
  selector: 'app-sidebar-options-tool',
  imports: [CommonModule, MatIcon, MatTooltip, TranslatePipe],
  template: `
    <button mat-icon-button matTooltip="{{ 'Options' | translate }}">
      <mat-icon>build</mat-icon>
    </button>
  `,
})
export class SidebarOptionsToolComponent {}
