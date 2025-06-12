import { Component, inject } from '@angular/core';
import { AppStore } from '../../../../../common/store/app.store';
import { Router } from '@angular/router';
import { GLOBAL_ROUTING_PATH } from '../../../../../common/constants/routing/routing';

@Component({
  selector: 'app-sidebar-avatar',
  template: `
    @let identity = this.appStore.identity(); @if (identity){
    <div class="flex items-center gap-4">
      <div
        (click)="navigate()"
        class="w-12 h-12 bg-identity bg-center bg-no-repeat bg-contain cursor-pointer"
      ></div>
      <div
        class="flex flex-col justify-between items-start font-medium dark:text-white"
      >
        <div>{{ identity.name }} {{ identity.surname }}</div>
        <div class="text-sm text-gray-500 dark:text-gray-400">
          {{ identity.email }}
        </div>
      </div>
    </div>
    }
  `,
})
export class SidebarAvatarComponent {
  public readonly appStore = inject(AppStore);
  private readonly router = inject(Router);

  public navigate(): void {
    this.router.navigate([GLOBAL_ROUTING_PATH.IDENTITY]);
  }
}
