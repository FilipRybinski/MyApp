import { Route } from '@angular/router';
import { ROUTES } from '../../common/constants/routing/routing';

export const DashboardRoutes: Route[] = [
  {
    path: ROUTES.DASHBOARD,
    loadComponent: () => import('./pages').then((m) => m.DashboardComponent),
    children: [],
  },
];
