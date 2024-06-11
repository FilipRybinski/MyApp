import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import { MaterialModule } from '../materialUI/material.module';
import { RouterLink } from '@angular/router';
import { PageNotFoundComponent } from './pages';
import { TitleCasePipe } from '@angular/common';

const declarationsAndExports = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Pages.HomeComponent,
];

const pipes = [TitleCasePipe];

@NgModule({
  declarations: [...declarationsAndExports, PageNotFoundComponent],
  imports: [MaterialModule, RouterLink, ...pipes],
  exports: [...declarationsAndExports, MaterialModule, ...pipes],
})
export class SharedModule {}
