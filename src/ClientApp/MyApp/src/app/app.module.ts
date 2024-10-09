import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InitializeService } from '../service/initialize/initialize.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { credentialsInterceptor } from '../interceptors/credentials.interceptor';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { StoreModule } from '@ngrx/store';
import { AppStore } from '../store/app.state';
import { EffectsModule } from '@ngrx/effects';

export function initialize(initializeService: InitializeService) {
  return () => initializeService.initialize();
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    SharedModule,
    AppRoutingModule,
    BrowserModule,
    StoreModule.forRoot(AppStore.reducers),
    EffectsModule.forRoot(AppStore.effects),
  ],
  providers: [
    provideAnimationsAsync(),
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
