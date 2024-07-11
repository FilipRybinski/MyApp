import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import * as Pages from './pages';
import { MarketplaceRoutingModule } from './marketplace-routing.module';

@NgModule({
  declarations: [Pages.MarketplaceComponent],
  imports: [MarketplaceRoutingModule, SharedModule],
})
export class MarketplaceModule {}
