import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import { MaterialModule } from '../materialUI/material.module';
import { RouterLink } from '@angular/router';
import { PageNotFoundComponent } from './pages';

const declarationsAndExports = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Pages.HomeComponent,
];

@NgModule({
  declarations: [...declarationsAndExports, PageNotFoundComponent],
  imports: [MaterialModule, RouterLink],
  exports: [...declarationsAndExports, MaterialModule],
})
export class SharedModule {}
