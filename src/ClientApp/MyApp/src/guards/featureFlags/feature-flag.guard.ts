import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import * as SharedService from '../../app/shared/service';
import { PATH } from '../../constants/routing/path';

export const featureFlagGuard: CanActivateFn = route => {
  const featureFlagService: SharedService.FeatureFlagService = inject(
    SharedService.FeatureFlagService
  );
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
