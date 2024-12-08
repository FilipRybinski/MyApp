import { NgModule } from '@angular/core';
import { AccountRoutingModule } from './account-routing.module';
import * as Pages from './pages';
import { AccountComponent } from './pages';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AccountService } from './service/account/account.service';

@NgModule({
  declarations: [
    Pages.AccountComponent,
    Pages.SignupComponent,
    Pages.SigninComponent,
    Pages.SettingsComponent,
  ],
  imports: [AccountRoutingModule, SharedModule, ReactiveFormsModule],
  exports: [AccountComponent],
  providers: [AccountService],
})
export class AccountModule {}
