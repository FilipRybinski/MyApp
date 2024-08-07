import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import * as Services from './service/index';
import { MaterialModule } from '../../modules/material.module';
import { RouterLink } from '@angular/router';
import { TitleCasePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

const components = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Components.NavbarMenuComponent,
];

const pages = [Pages.HomeComponent, Pages.PageNotFoundComponent];

const services = [Services.AlertService, Services.SharedService];

const dependencies = [MaterialModule, RouterLink, HttpClientModule];

const pipes = [TitleCasePipe];

@NgModule({
  declarations: [...pages, ...components],
  imports: [...dependencies, ...pipes],
  exports: [...dependencies, ...pages, ...components, ...pipes],
  providers: [...services],
})
export class SharedModule {}
