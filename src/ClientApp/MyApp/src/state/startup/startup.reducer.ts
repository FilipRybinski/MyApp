import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { LoggedInUser } from '../../interfaces/account/loggedInUser';
import {
  attachFeatureFlags,
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
  ),
  on(
    attachFeatureFlags,
    (state, { featureFlags }): Startup => ({ ...state, featureFlags })
  )
);
