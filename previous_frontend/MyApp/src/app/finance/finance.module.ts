import { NgModule } from '@angular/core';
import { FinanceRoutingModule } from './finance-routing.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.FinanceComponent],
  imports: [FinanceRoutingModule],
})
export class FinanceModule {}
