import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { lastValueFrom } from 'rxjs';
import { User } from '../../../../interfaces/account/user';
import { FeatureFlags } from '../../../../interfaces/featureFlags/featureFlags';
import { AuthService } from '../auth/auth.service';
import { FeatureFlagService } from '../featureFlag/feature-flag.service';

@Injectable()
export class InitializeService {
  constructor(
    private readonly http: HttpClient,
    private readonly auth: AuthService,
    private readonly featureFlags: FeatureFlagService
  ) {}

  public async initialize(): Promise<void> {
    try {
      this.auth.setAuthUser = await this.isAuthorized();
      this.featureFlags.setFeatureFlags = await this.getFeatureFlags();
      console.log('InitializeService initialized');
    } catch (error) {
      console.error('Failed to initialize application', error);
    }
  }

  private async isAuthorized(): Promise<User> {
    return lastValueFrom(
      this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED)
    );
  }

  private async getFeatureFlags(): Promise<FeatureFlags> {
    return lastValueFrom(
      this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS)
    );
  }
}
