import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { FeatureFlagService } from '../../service/featureFlag/feature-flag.service';
import { getHomeUrl } from '../../constants/routing/path';
import { AlertService } from '../../service/alert/alert.service';

export const featureFlagGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot
) => {
  const router: Router = inject(Router);
  const featureFlagService: FeatureFlagService = inject(FeatureFlagService);
  const alertService: AlertService = inject(AlertService);
  const {
    data: { feature },
  } = route;

  if (feature) {
    const result = featureFlagService.isFeatureFlagEnabled(feature);
    if (!result) {
      router
        .navigate(getHomeUrl())
        .then(() => alertService.handleWorkInProgress());
    }
    return result;
  }
  return false;
};
