import { NgModule } from '@angular/core';
import * as Components from './components';
import { MaterialModule } from '../materialUI/material.module';

const declarationsAndExports = [
  Components.NavbarComponent,
  Components.FooterComponent,
];

@NgModule({
  declarations: [...declarationsAndExports],
  imports: [MaterialModule],
  exports: [...declarationsAndExports],
})
export class SharedModule {}
