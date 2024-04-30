import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';
import * as Pages from './pages';

@NgModule({
  declarations: [Pages.HomeComponent],
  imports: [HomeRoutingModule],
})
export class HomeModule {}
