import { Component, signal, WritableSignal } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@Component({
  selector: 'app-layout',
  imports: [NavbarComponent, SidebarComponent],
  template: ` <app-navbar [(isSidebarOpen)]="isSidebarOpen" />
    <app-sidebar [isSidebarOpen]="isSidebarOpen()" />`,
})
export class LayoutComponent {
  isSidebarOpen: WritableSignal<boolean> = signal<boolean>(false);
}
