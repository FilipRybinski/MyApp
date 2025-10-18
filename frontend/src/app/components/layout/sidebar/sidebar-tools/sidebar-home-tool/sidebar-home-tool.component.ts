import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { TranslatePipe } from '@ngx-translate/core';
import { MatTooltip } from '@angular/material/tooltip';
import { GLOBAL_ROUTING_PATH } from '../../../../../../common/constants/routing/routing';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-sidebar-home-tool',
  imports: [CommonModule, MatIcon, MatTooltip, TranslatePipe, RouterLink],
  template: ` <button
    [routerLink]="[GLOBAL_ROUTING_PATH.HOME]"
    mat-icon-button
    matTooltip="{{ 'Home' | translate }}"
  >
    <mat-icon>home</mat-icon>
  </button>`,
})
export class SidebarHomeToolComponent {
  protected readonly GLOBAL_ROUTING_PATH = GLOBAL_ROUTING_PATH;
}
