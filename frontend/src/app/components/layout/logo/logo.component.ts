import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { GLOBAL_ROUTING_PATH } from '../../../../common/constants/routing/routing';

@Component({
  selector: 'app-logo',
  imports: [CommonModule, MatIconModule, RouterLink],
  template: ` <div
    [routerLink]="[GLOBAL_ROUTING_PATH.HOME]"
    class="w-8 h-8 bg-logo bg-center bg-no-repeat bg-contain cursor-pointer"
  ></div>`,
})
export class LogoComponent {
  protected readonly GLOBAL_ROUTING_PATH = GLOBAL_ROUTING_PATH;
}
