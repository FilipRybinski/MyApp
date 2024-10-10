import { User } from '../../interfaces/account/user';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { createAction, props } from '@ngrx/store';

enum startupActions {
  loadInitialData = '[Startup] Load initial data',
  AuthorizeUser = '[StartUp] Authorize user',
  DeauthorizeUser = '[StartUp] Deauthorize user',
  AttachFeatureFlags = '[StartUp] Attach feature flags',
}

export const authorizeUser = createAction(
  startupActions.AuthorizeUser,
  props<{ user: User }>()
);

export const deauthorizeUser = createAction(startupActions.DeauthorizeUser);

export const attachFeatureFlags = createAction(
  startupActions.AttachFeatureFlags,
  props<{ featureFlags: FeatureFlags }>()
);

export const loadInitialData = createAction(startupActions.loadInitialData);
