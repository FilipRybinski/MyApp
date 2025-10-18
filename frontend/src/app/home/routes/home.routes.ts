import { Route } from '@angular/router';

export const HOME_ROUTING_PATH = {
  HOME: 'home',
};

export const homeRoutes: Route[] = [
  {
    path: '',
    loadComponent: () => import('../pages').then((m) => m.HomeComponent),
  },
];
