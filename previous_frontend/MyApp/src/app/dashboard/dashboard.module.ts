import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import * as Pages from './pages';
import * as Components from './components';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [Pages.DashboardComponent, Components.DashboardMenuComponent],
  imports: [DashboardRoutingModule, SharedModule],
})
export class DashboardModule {}
