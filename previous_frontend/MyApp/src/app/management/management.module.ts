import { NgModule } from '@angular/core';
import { ManagementRoutingModule } from './management-routing.module';
import { SharedModule } from '../shared/shared.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.ManagementComponent],
  imports: [ManagementRoutingModule, SharedModule],
})
export class ManagementModule {}
