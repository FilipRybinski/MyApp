import { NgModule } from '@angular/core';
import * as Components from './components';
import * as Pages from './pages';
import { MaterialModule } from '../../modules/material.module';
import { RouterLink } from '@angular/router';
import { TitleCasePipe } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

const components = [
  Components.NavbarComponent,
  Components.FooterComponent,
  Components.NavbarMenuComponent,
  Components.NavbarLanguagesMenuComponent,
  Components.BottomSheetLanguagesMenuComponent,
];

const pages = [Pages.HomeComponent, Pages.PageNotFoundComponent];

const dependencies = [MaterialModule, RouterLink, TranslateModule];

const pipes = [TitleCasePipe];

@NgModule({
  declarations: [...pages, ...components],
  exports: [...dependencies, ...pages, ...components, ...pipes],
  imports: [...dependencies, ...pipes],
})
export class SharedModule {}
