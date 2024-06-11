import { Injectable } from '@angular/core';
import { FeatureFlags } from '../../../interfaces/featureFlags/featureFlags';
import { User } from '../../../interfaces/account/user';

type Nullable<T> = T | null;

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  private featureFlags: Nullable<FeatureFlags> = null;
  private currentUser: Nullable<User> = null;

  public loadInitialState(): void {
    this.currentUser = null;
    this.featureFlags = null;
  }

  set flags(flags: Nullable<FeatureFlags>) {
    this.featureFlags = flags;
  }

  get flags(): Nullable<FeatureFlags> {
    return this.featureFlags;
  }

  set user(user: Nullable<User>) {
    this.currentUser = user;
  }

  get user(): Nullable<User> {
    return this.currentUser;
  }
}
