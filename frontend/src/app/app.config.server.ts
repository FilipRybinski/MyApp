import {
  ApplicationConfig,
  importProvidersFrom,
  mergeApplicationConfig,
} from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { ServerTranslationExtensionModule } from '../common/constants/translation/server.translation.extension.module';

const config: ApplicationConfig = {
  providers: [
    provideServerRendering(),
    provideHttpClient(withFetch()),
    importProvidersFrom(ServerTranslationExtensionModule),
  ],
};

export const serverConfig = mergeApplicationConfig(appConfig, config);
