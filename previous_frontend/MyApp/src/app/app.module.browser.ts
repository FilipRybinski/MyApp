import { NgModule } from '@angular/core';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { BrowserTranslationExtensionModule } from '../modules/browser.translation.extension.module';

@NgModule({
  imports: [AppModule, BrowserTranslationExtensionModule],
  bootstrap: [AppComponent],
})
export class AppBrowserModule {}
