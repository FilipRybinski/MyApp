import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import * as Pages from './pages';
import { SharedModule } from '../shared/shared.module';
import { DashboardMenuComponent } from './components/dashboard-menu/dashboard-menu.component';

@NgModule({
  declarations: [Pages.DashboardComponent, DashboardMenuComponent],
  imports: [DashboardRoutingModule, SharedModule],
})
export class DashboardModule {}
