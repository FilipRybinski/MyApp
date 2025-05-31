import {
  ApplicationConfig,
  importProvidersFrom,
  mergeApplicationConfig,
} from '@angular/core';
import { appConfig } from './app.config';
import { BrowserTranslationExtensionModule } from '../common/constants/translation/browser.translation.extension.module';

const config: ApplicationConfig = {
  providers: [importProvidersFrom(BrowserTranslationExtensionModule)],
};

export const browserConfig = mergeApplicationConfig(appConfig, config);
