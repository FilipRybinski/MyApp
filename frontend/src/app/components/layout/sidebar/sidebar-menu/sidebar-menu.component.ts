import { Component, inject } from '@angular/core';
import { MatListItem, MatNavList } from '@angular/material/list';
import { GLOBAL_ROUTING_PATH } from '../../../../../common/constants/routing/routing';
import { Router } from '@angular/router';
import { MatIcon } from '@angular/material/icon';
import { AppStore } from '../../../../../common/store/app.store';
import { TranslatePipe } from '@ngx-translate/core';

interface MenuItems {
  route: string[];
  displayName: string;
  icon: string;
  isVisible?: () => boolean;
}

@Component({
  selector: 'app-sidebar-menu',
  imports: [MatNavList, MatListItem, MatIcon, TranslatePipe],
  template: `
    <mat-nav-list class="!flex !flex-col gap-2">
      @for (item of menuItems; track item.route) { @if (!item.isVisible ||
      item.isVisible()) {
      <mat-list-item
        [activated]="isActive(item)"
        (click)="navigate(item.route)"
      >
        <div class="flex items-center justify-between gap-2 w-full">
          <span class="text-sm">{{ item.displayName | translate }}</span>
          <mat-icon class="text-center">{{ item.icon }}</mat-icon>
        </div>
      </mat-list-item>
      } }
    </mat-nav-list>
  `,
})
export class SidebarMenuComponent {
  private readonly appStore = inject(AppStore);
  private readonly router = inject(Router);

  public readonly menuItems: MenuItems[] = [
    {
      route: [GLOBAL_ROUTING_PATH.IDENTITY, GLOBAL_ROUTING_PATH.SIGN_IN],
      displayName: 'SignIn',
      icon: 'login',
      isVisible: () => !this.appStore.identity(),
    },
    {
      route: [GLOBAL_ROUTING_PATH.IDENTITY, GLOBAL_ROUTING_PATH.SIGN_UP],
      displayName: 'SignUp',
      icon: 'person_add',
      isVisible: () => !this.appStore.identity(),
    },
    {
      route: [GLOBAL_ROUTING_PATH.IDENTITY, GLOBAL_ROUTING_PATH.IDENTITY],
      displayName: 'Account',
      icon: 'account_circle',
      isVisible: () => !!this.appStore.identity(),
    },
    {
      route: [GLOBAL_ROUTING_PATH.IDENTITY, GLOBAL_ROUTING_PATH.IDENTITY],
      displayName: 'Account',
      icon: 'account_circle',
      isVisible: () => !!this.appStore.identity(),
    },
    {
      route: [GLOBAL_ROUTING_PATH.FEE_TRACKER],
      displayName: 'FeeTracker',
      icon: 'track_changes',
    },
  ];

  public navigate(url: string[]): void {
    this.router.navigate(url);
  }

  public isActive(item: MenuItems): boolean {
    const currentUrl = this.router.url;
    const targetPath = '/' + item.route.join('/');
    return currentUrl.startsWith(targetPath);
  }
}
