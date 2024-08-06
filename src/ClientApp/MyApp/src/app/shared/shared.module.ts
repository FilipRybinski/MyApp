import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import * as Services from './service/index';
import { MaterialModule } from './material.module';
import { RouterLink } from '@angular/router';
import { TitleCasePipe } from '@angular/common';

const components = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Pages.HomeComponent,
];

const pages = [Pages.HomeComponent, Pages.PageNotFoundComponent];

const services = [Services.AlertService];

const pipes = [TitleCasePipe];

@NgModule({
  declarations: [...pages, ...components],
  imports: [MaterialModule, RouterLink, ...pipes],
  exports: [MaterialModule, ...pages, ...components, ...pipes],
  providers: [...services],
})
export class SharedModule {}
