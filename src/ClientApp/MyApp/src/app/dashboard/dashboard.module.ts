import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import * as Pages from './pages';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [Pages.DashboardComponent],
  imports: [DashboardRoutingModule, SharedModule],
})
export class DashboardModule {}
