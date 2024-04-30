import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.DashboardComponent],
  imports: [DashboardRoutingModule],
})
export class DashboardModule {}
