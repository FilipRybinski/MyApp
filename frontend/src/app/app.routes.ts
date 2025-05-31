import { Route } from '@angular/router';
import { GLOBAL_ROUTING_PATH } from '../common/constants/routing/routing';
import * as Guards from '../common/guards';
import { FeatureFlag } from '../common/enums/featureFlag';

export const appRoutes: Route[] = [
  {
    path: '',
    redirectTo: GLOBAL_ROUTING_PATH.HOME,
    pathMatch: 'full',
  },
  {
    path: GLOBAL_ROUTING_PATH.HOME,
    loadChildren: () =>
      import('./home/routes/home.routes').then((m) => m.homeRoutes),
  },
  {
    path: GLOBAL_ROUTING_PATH.IDENTITY,
    loadChildren: () =>
      import('./identity/routes/identity.routes').then((m) => m.identityRoutes),
  },
  {
    path: GLOBAL_ROUTING_PATH.FEE_TRACKER,
    loadChildren: () =>
      import('./fee-tracker/routes/fee-tracker.routes').then(
        (m) => m.feeTrackerRoutes
      ),
    canActivate: [Guards.featureFlagGuard],
    canActivateChild: [Guards.featureFlagGuard],
    data: { feature: FeatureFlag.FEE_TRACKER },
  },
  {
    path: GLOBAL_ROUTING_PATH.WILDCARD,
    redirectTo: GLOBAL_ROUTING_PATH.HOME,
  },
];
