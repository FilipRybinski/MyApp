import { Injectable, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { HttpClient } from '@angular/common/http';
import { AppStore } from '../../store/app.store';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  private readonly appStore = inject(AppStore);
  private readonly http = inject(HttpClient);

  public async initialize(): Promise<void> {
    try {
      const user = await firstValueFrom(
        this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED)
      );
      const featureFlags = await firstValueFrom(
        this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS)
      );

      this.appStore.attachInitialData(user, featureFlags);
    } catch (error) {
      console.error('Failed to initialize service');
    }
  }
}
