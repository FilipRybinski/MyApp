import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { getHomeUrl } from '../../constants/routing/path';
import { AlertService } from '../../service/alert/alert.service';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { selectFeatureFlags } from '../../state/startup/startup.selectors';
import { Store } from '@ngrx/store';

export const featureFlagGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot
) => {
  const router: Router = inject(Router);
  const alertService: AlertService = inject(AlertService);
  const store = inject(Store);
  const featureFlags$ = store.selectSignal(selectFeatureFlags);
  const {
    data: { feature },
  } = route;

  if (feature) {
    const result = isFeatureFlagEnabled(feature, featureFlags$());
    if (!result) {
      router
        .navigate(getHomeUrl())
        .then(() => alertService.handleWorkInProgress());
    }
    return result;
  }
  return false;
};

const isFeatureFlagEnabled = (
  featureFlag: keyof FeatureFlags,
  featureFlags: FeatureFlags
): boolean => {
  if (featureFlags) {
    return featureFlags[featureFlag];
  }
  return false;
};
