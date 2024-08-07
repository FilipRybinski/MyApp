import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { FeatureFlagService } from '../../service/featureFlag/feature-flag.service';
import { getHomeUrl } from '../../constants/routing/path';

export const featureFlagGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot
) => {
  const router: Router = inject(Router);
  const featureFlagService: FeatureFlagService = inject(FeatureFlagService);
  const {
    data: { feature },
  } = route;

  if (feature) {
    const result = featureFlagService.isFeatureFlagEnabled(feature);
    !result && router.navigate(getHomeUrl());
    return result;
  }

  return false;
};
