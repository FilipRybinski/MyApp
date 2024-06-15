import { NgModule } from '@angular/core';
import { ManagementRoutingModule } from './management-routing.module';
import * as Pages from './pages';
import * as Dialogs from './dialogs';
import * as Components from './components';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    Pages.ManagementComponent,
    Dialogs.CreateTeamComponent,
    Components.MyTeamComponent,
    Components.AvailableMembersComponent,
  ],
  imports: [ManagementRoutingModule, SharedModule, ReactiveFormsModule],
})
export class ManagementModule {}
