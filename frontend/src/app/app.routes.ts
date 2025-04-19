import { Route } from '@angular/router';
import { ROUTES } from 'src/common/constants/routing/routing';
import { DashboardRoutes } from './dashboard/dashboard.routes';

export const appRoutes: Route[] = [
  {
    path: '',
    redirectTo: ROUTES.DASHBOARD,
    pathMatch: 'full',
  },
  ...DashboardRoutes,
];
