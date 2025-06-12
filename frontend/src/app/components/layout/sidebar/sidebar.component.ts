import { Component, input } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidebarMenuComponent } from './sidebar-menu/sidebar-menu.component';
import { SidebarAvatarComponent } from './sidebar-avatar/sidebar-avatar.component';
import { SidebarToolsComponent } from './sidebar-tools/sidebar-tools.component';

@Component({
  selector: 'app-sidebar',
  imports: [
    RouterOutlet,
    MatSidenavModule,
    SidebarMenuComponent,
    SidebarAvatarComponent,
    SidebarToolsComponent,
  ],
  template: `
    <mat-sidenav-container class="h-[calc(100vh-64px)]">
      <mat-sidenav
        class="!rounded-md !shadow-md !w-64"
        [mode]="'side'"
        [opened]="isSidebarOpen()"
      >
        <app-sidebar-avatar class="mb-4" />
        <app-sidebar-tools class="flex items-center gap-2" />
        <app-sidebar-menu class="w-full" />
      </mat-sidenav>
      <mat-sidenav-content class="pt-4">
        <router-outlet></router-outlet>
      </mat-sidenav-content>
    </mat-sidenav-container>
  `,
})
export class SidebarComponent {
  isSidebarOpen = input.required<boolean>();
}
