import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InitializeService } from '../service/initialize/initialize.service';
import { AppRoutingModule } from './app-routing.module';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {
  HttpClient,
  provideHttpClient,
  withInterceptors,
} from '@angular/common/http';
import { credentialsInterceptor } from '../interceptors/credentials.interceptor';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { StoreModule } from '@ngrx/store';
import { AppState } from '../state/app.state';
import { LoadingPageComponent } from './shared/pages/loading-page/loading-page.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { translationConfig } from '../constants/translation/translation';
import { Languages } from '../enums/languages';

export function initialize(initializeService: InitializeService) {
  return () => initializeService.initialize();
}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(
    http,
    translationConfig.directory,
    translationConfig.extension
  );
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    LoadingPageComponent,
    SharedModule,
    AppRoutingModule,
    BrowserModule,
    StoreModule.forRoot(AppState.reducers),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
      defaultLanguage: Languages.PL,
    }),
  ],
  providers: [
    provideAnimationsAsync(),
    provideClientHydration(),
    provideHttpClient(withInterceptors([credentialsInterceptor])),
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 3000 } },
    {
      provide: APP_INITIALIZER,
      useFactory: initialize,
      deps: [InitializeService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
