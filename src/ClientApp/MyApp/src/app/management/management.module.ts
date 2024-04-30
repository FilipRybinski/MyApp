import { NgModule } from '@angular/core';
import { ManagementRoutingModule } from './management-routing.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.ManagementComponent],
  imports: [ManagementRoutingModule],
})
export class ManagementModule {}
