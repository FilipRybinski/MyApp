import { AppState } from '../app.state';
import { createSelector } from '@ngrx/store';

const selectStartup = (state: AppState) => state.startup;
export const selectLoggedUser = createSelector(
  selectStartup,
  selectStartup => selectStartup.loggedInUser.user
);
export const selectIsLoggedUserAuthorized = createSelector(
  selectStartup,
  selectStartup => selectStartup.loggedInUser.isAuth
);

export const selectFeatureFlags = createSelector(
  selectStartup,
  selectStartup => selectStartup.featureFlags
);
