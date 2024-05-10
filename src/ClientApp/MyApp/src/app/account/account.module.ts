import { NgModule } from '@angular/core';
import { AccountRoutingModule } from './account-routing.module';
import * as Pages from './pages';
import { AccountComponent } from './pages';

@NgModule({
  declarations: [Pages.AccountComponent],
  imports: [AccountRoutingModule],
  exports: [AccountComponent],
})
export class AccountModule {}
