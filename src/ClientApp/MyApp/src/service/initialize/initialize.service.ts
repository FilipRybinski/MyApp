import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Store } from '@ngrx/store';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { attachInitialData } from '../../state/startup/startup.action';
import { HttpClient } from '@angular/common/http';
import { isPlatformServer } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  constructor(
    private readonly store: Store,
    private readonly http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: NonNullable<unknown>
  ) {}

  public async initialize(): Promise<void> {
    if (isPlatformServer(this.platformId)) {
      return;
    }
    try {
      const user = await firstValueFrom(
        this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED)
      );
      const featureFlags = await firstValueFrom(
        this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS)
      );

      this.store.dispatch(attachInitialData({ user, featureFlags }));
    } catch (error) {
      console.error('Failed to initialize service');
    }
  }
}
