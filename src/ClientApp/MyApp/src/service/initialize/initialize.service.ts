import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { attachInitialData } from '../../state/startup/startup.action';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  constructor(
    private readonly store: Store,
    private readonly http: HttpClient
  ) {}

  public async initialize(): Promise<void> {
    try {
      const [user, featureFlags] = await Promise.all([
        firstValueFrom(
          this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED)
        ),
        firstValueFrom(
          this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS)
        ),
      ]);
      this.store.dispatch(attachInitialData({ user, featureFlags }));
    } catch (error) {
      console.error('Failed to initialize service');
    }
  }
}
