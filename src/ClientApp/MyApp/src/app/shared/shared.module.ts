import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import * as Services from './service/index';
import { MaterialModule } from '../../modules/material.module';
import { RouterLink } from '@angular/router';
import { TitleCasePipe } from '@angular/common';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { credentialsInterceptor } from '../../interceptors/credentials.interceptor';

const components = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Components.NavbarMenuComponent,
];

const pages = [Pages.HomeComponent, Pages.PageNotFoundComponent];

const services = [
  Services.AlertService,
  Services.SharedService,
  provideHttpClient(withInterceptors([credentialsInterceptor])),
];

const dependencies = [MaterialModule, RouterLink];

const pipes = [TitleCasePipe];

@NgModule({
  declarations: [...pages, ...components],
  imports: [...dependencies, ...pipes],
  exports: [...dependencies, ...pages, ...components, ...pipes],
  providers: [...services],
})
export class SharedModule {}
