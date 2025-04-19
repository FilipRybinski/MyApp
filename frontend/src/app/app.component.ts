import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/pages';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';

@Component({
  imports: [
    RouterModule,
    DashboardComponent,
    NavbarComponent,
    SidebarComponent,
  ],
  selector: 'app-root',
  template: ` <app-navbar />
    <app-sidebar />`,
})
export class AppComponent {
  title = 'frontend';
}
