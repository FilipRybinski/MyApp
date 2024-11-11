import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { TranslationExtensionModule } from '../modules/translation.extension.module';

@NgModule({
  imports: [AppModule, ServerModule, TranslationExtensionModule],
  providers: [provideHttpClient(withFetch())],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
