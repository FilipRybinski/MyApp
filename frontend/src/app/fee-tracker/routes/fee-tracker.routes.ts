import { Route } from '@angular/router';

export const FEE_TRACKER_ROUTING_PATH = {
  FEE_TRACKER: 'fee-tracker',
};

export const feeTrackerRoutes: Route[] = [
  {
    path: '',
    loadComponent: () => import('../pages/').then((m) => m.FeeTrackerComponent),
  },
];
