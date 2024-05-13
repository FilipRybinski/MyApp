import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import { MaterialModule } from '../materialUI/material.module';

const declarationsAndExports = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Pages.HomeComponent,
];

@NgModule({
  declarations: [...declarationsAndExports],
  imports: [MaterialModule],
  exports: [...declarationsAndExports],
})
export class SharedModule {}
