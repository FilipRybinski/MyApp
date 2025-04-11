import { FeatureFlags } from '../interfaces/featureFlags/featureFlags';
import { LoggedInUser } from '../interfaces/account/loggedInUser';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { User } from '../interfaces/account/user';

interface AppStore {
  featureFlags: FeatureFlags;
  loggedInUser: LoggedInUser;
}

const initialState: AppStore = {
  featureFlags: {
    dashboard: false,
    finance: false,
    management: false,
    marketplace: false,
  },
  loggedInUser: {
    user: null,
    isAuth: false,
  },
};

export const AppStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(store => ({
    attachInitialData(
      user: User | null,
      featureFlags: FeatureFlags | null
    ): void {
      patchState(store, {
        featureFlags: featureFlags ?? initialState.featureFlags,
        loggedInUser: {
          user: user,
          isAuth: !!user,
        },
      });
    },
    authorizeUser(user: User | null): void {
      patchState(store, {
        loggedInUser: {
          user: user,
          isAuth: !!user,
        },
      });
    },
    deauthorizeUser(): void {
      patchState(store, {
        loggedInUser: {
          user: null,
          isAuth: false,
        },
      });
    },
  }))
);
