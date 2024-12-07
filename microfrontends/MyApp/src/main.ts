import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppBrowserModule } from './app/app.module.browser';

platformBrowserDynamic()
  .bootstrapModule(AppBrowserModule)
  .catch(err => console.error(err));
