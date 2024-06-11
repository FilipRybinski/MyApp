import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom, Observable } from 'rxjs';
import { User } from '../../../interfaces/account/user';
import { environment } from '../../../environments/environment';
import { FeatureFlags } from '../../../interfaces/featureFlags/featureFlags';

@Injectable({
  providedIn: 'root',
})
export class InitializeService {
  public featureFlags!: FeatureFlags;
  public currentUser!: User;

  constructor(private readonly _http: HttpClient) {}

  public async initialize(): Promise<void> {
    try {
      await firstValueFrom(this.getMyAccount()).then(async user => {
        this.currentUser = user;
        this.featureFlags = await firstValueFrom(this.getFeatureFlags());
      });
    } catch (error) {
      console.error('Failed to initialize application', error);
    }
  }

  private getMyAccount(): Observable<User> {
    return this._http.get<User>(environment.URL.ACCOUNT.GET_MY_ACCOUNT);
  }

  private getFeatureFlags(): Observable<FeatureFlags> {
    return this._http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS);
  }
}
