import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { LoggedInUser } from '../../interfaces/account/loggedInUser';
import {
  attachInitialData,
  authorizeUser,
  deauthorizeUser,
} from './startup.action';
import { Startup } from '../../interfaces/state/startup';
import { createReducer, on } from '@ngrx/store';

export const initialFeatureFlagsState: FeatureFlags = {
  dashboard: false,
  finance: false,
  management: false,
  marketplace: false,
};

export const initialLoggedInUserState: LoggedInUser = {
  user: null,
  isAuth: false,
};

export const initialStartupState: Startup = {
  loggedInUser: initialLoggedInUserState,
  featureFlags: initialFeatureFlagsState,
};

export const StartupReducer = createReducer(
  initialStartupState,
  on(
    attachInitialData,
    (state, { user, featureFlags }): Startup => ({
      loggedInUser: {
        user: user ?? null,
        isAuth: !!user,
      },
      featureFlags,
    })
  ),
  on(
    authorizeUser,
    (state, { user }): Startup => ({
      ...state,
      loggedInUser: {
        user: user ?? null,
        isAuth: !!user,
      },
    })
  ),
  on(
    deauthorizeUser,
    (state): Startup => ({ ...state, loggedInUser: initialLoggedInUserState })
  )
);
