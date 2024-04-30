import { NgModule } from '@angular/core';
import { AccountRoutingModule } from './account-routing.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.AccountComponent],
  imports: [AccountRoutingModule],
})
export class AccountModule {}
