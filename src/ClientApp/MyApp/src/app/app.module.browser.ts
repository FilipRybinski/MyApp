import { NgModule } from '@angular/core';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { TranslationExtensionModule } from '../modules/translation.extension.module';

@NgModule({
  imports: [AppModule, TranslationExtensionModule],
  bootstrap: [AppComponent],
})
export class AppBrowserModule {}
