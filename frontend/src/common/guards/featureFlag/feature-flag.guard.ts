import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { AppStore } from '../../store/app.store';
import { getGlobalHomeUrl } from '../../constants/routing/routing';
import { AlertService } from '../../services/alert/alert.service';

export const featureFlagGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot
) => {
  const router: Router = inject(Router);
  const alertService: AlertService = inject(AlertService);
  const appStore = inject(AppStore);
  const {
    data: { feature },
  } = route;

  if (feature) {
    const result = isFeatureFlagEnabled(feature, appStore.featureFlags());
    if (!result) {
      router
        .navigate(getGlobalHomeUrl())
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
