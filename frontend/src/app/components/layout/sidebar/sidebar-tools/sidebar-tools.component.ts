import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarLanguageToolComponent } from './sidebar-language-tool/sidebar-language-tool.component';
import { SidebarThemeToolComponent } from './sidebar-theme-tool/sidebar-theme-tool.component';
import { SidebarOptionsToolComponent } from './sidebar-options-tool/sidebar-options-tool.component';
import { SidebarInfoToolComponent } from './sidebar-info-tool/sidebar-info-tool.component';
import { SidebarHomeToolComponent } from './sidebar-home-tool/sidebar-home-tool.component';
import { SidebarLogoutToolComponent } from './sidebar-logout-tool/sidebar-logout-tool.component';
import { AppStore } from '../../../../../common/store/app.store';

@Component({
  selector: 'app-sidebar-tools',
  imports: [
    CommonModule,
    SidebarLanguageToolComponent,
    SidebarThemeToolComponent,
    SidebarOptionsToolComponent,
    SidebarInfoToolComponent,
    SidebarHomeToolComponent,
    SidebarLogoutToolComponent,
  ],
  template: `
    <app-sidebar-home-tool />
    @let identity = this.appStore.identity(); @if (identity) {
    <app-sidebar-options-tool />
    }
    <app-sidebar-language-tool />
    <app-sidebar-theme-tool />
    <app-sidebar-info-tool />
    @if (identity) {
    <app-sidebar-logout-tool />
    }
  `,
})
export class SidebarToolsComponent {
  public readonly appStore = inject(AppStore);
}
