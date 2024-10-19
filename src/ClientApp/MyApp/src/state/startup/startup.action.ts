import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { createAction, props } from '@ngrx/store';

enum startupActions {
  attachInitialData = '[Startup] Attach initial data',
  AuthorizeUser = '[StartUp] Authorize user',
  DeauthorizeUser = '[StartUp] Deauthorize user',
}

export const authorizeUser = createAction(
  startupActions.AuthorizeUser,
  props<{ user: User }>()
);

export const deauthorizeUser = createAction(startupActions.DeauthorizeUser);

export const attachInitialData = createAction(
  startupActions.attachInitialData,
  props<{ user: User; featureFlags: FeatureFlags; isLoading: boolean }>()
);
