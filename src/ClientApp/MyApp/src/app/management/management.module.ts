import { NgModule } from '@angular/core';
import { ManagementRoutingModule } from './management-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ManagementComponent } from './pages/management/management.component';

@NgModule({
  declarations: [
    ManagementComponent
  ],
  imports: [ManagementRoutingModule, SharedModule, ReactiveFormsModule],
})
export class ManagementModule {}
