import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { PATH } from '../../constants/routing/path';
import { FeatureFlagService } from '../../service/featureFlag/feature-flag.service';

export const featureFlagGuard: CanActivateFn = route => {
  const featureFlagService: FeatureFlagService = inject(FeatureFlagService);
  const featureFlags = featureFlagService.getFeatureFlags;
  console.log(route.routeConfig?.path);
  switch (route.routeConfig?.path) {
    case PATH.DASHBOARD:
      return featureFlags!.dashboardFeatureFlag;
    case PATH.FINANCE:
      return featureFlags!.financeFeatureFlag;
    case PATH.MANAGEMENT:
      return featureFlags!.managementFeatureFlag;
    default:
      return true;
  }
};
