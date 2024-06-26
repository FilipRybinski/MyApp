import { NgModule } from '@angular/core';
import { AccountRoutingModule } from './account-routing.module';
import * as Pages from './pages';
import { AccountComponent } from './pages';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    Pages.AccountComponent,
    Pages.SignupComponent,
    Pages.SigninComponent,
  ],
  imports: [AccountRoutingModule, SharedModule, ReactiveFormsModule],
  exports: [AccountComponent],
})
export class AccountModule {}
