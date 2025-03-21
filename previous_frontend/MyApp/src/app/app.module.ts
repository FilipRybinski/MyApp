import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InitializeService } from '../service/initialize/initialize.service';
import { AppRoutingModule } from './app-routing.module';
import {
  BrowserModule,
  provideClientHydration,
  withEventReplay,
} from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { credentialsInterceptor } from '../interceptors/credentials.interceptor';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { TranslateModule } from '@ngx-translate/core';

import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { GlobalErrorHandler } from '../interceptors/global-error-handler';
import { httpErrorHandlerInterceptor } from '../interceptors/http-error-handler.interceptor';

export function initialize(initializeService: InitializeService) {
  return () => initializeService.initialize();
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    SharedModule,
    AppRoutingModule,
    BrowserModule,
    TranslateModule.forChild(),
  ],
  providers: [
    SsrCookieService,
    provideAnimationsAsync(),
    provideClientHydration(withEventReplay()),
    provideHttpClient(
      withInterceptors([credentialsInterceptor, httpErrorHandlerInterceptor])
    ),
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 3000 } },
    {
      provide: APP_INITIALIZER,
      useFactory: initialize,
      deps: [InitializeService],
      multi: true,
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
