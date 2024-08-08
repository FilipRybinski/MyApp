import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InitializeService } from '../service/initialize/initialize.service';
import { AuthService } from '../service/auth/auth.service';
import { FeatureFlagService } from '../service/featureFlag/feature-flag.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

export function initialize(initializeService: InitializeService) {
  return () => initializeService.initialize();
}

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, AppRoutingModule, BrowserModule],
  providers: [
    provideAnimationsAsync(),
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
