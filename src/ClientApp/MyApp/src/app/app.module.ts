import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SharedModule } from './shared/shared.module';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { credentialsInterceptor } from '../interceptors/credentials.interceptor';
import { InitializeService } from '../service/initialize/initialize.service';
import { AuthService } from '../service/auth/auth.service';
import { FeatureFlagService } from '../service/featureFlag/feature-flag.service';

export function initialize(initializeService: InitializeService) {
  return () => initializeService.initialize();
}

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(withInterceptors([credentialsInterceptor])),
    InitializeService,
    AuthService,
    FeatureFlagService,
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
