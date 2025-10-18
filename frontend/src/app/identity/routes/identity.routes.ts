import { Route } from '@angular/router';

export const IDENTITY_ROUTING_PATH = {
  IDENTITY: 'identity',
  SIGN_IN: 'sign-in',
  SIGN_UP: 'sign-up',
  CONFIRMATION: 'confirmation',
  RESET_PASSWORD: 'reset-password',
};

export const IDENTITY_PARAMS = {
  IDENTITY: 'id',
  TOKEN: 'token',
};

export const identityRoutes: Route[] = [
  {
    path: '',
    loadComponent: () => import('../pages').then((m) => m.IdentityComponent),
  },
  {
    path: IDENTITY_ROUTING_PATH.SIGN_IN,
    loadComponent: () =>
      import('../pages').then((m) => m.IdentitySignInComponent),
  },
  {
    path: IDENTITY_ROUTING_PATH.SIGN_UP,
    loadComponent: () =>
      import('../pages').then((m) => m.IdentitySignUpComponent),
  },
  {
    path: `${IDENTITY_ROUTING_PATH.RESET_PASSWORD}/:${IDENTITY_PARAMS.IDENTITY}/:${IDENTITY_PARAMS.TOKEN}`,
    loadComponent: () =>
      import('../pages').then((m) => m.IdentityResetPasswordComponent),
  },
  {
    path: `${IDENTITY_ROUTING_PATH.CONFIRMATION}/:${IDENTITY_PARAMS.IDENTITY}/:${IDENTITY_PARAMS.TOKEN}`,
    loadComponent: () =>
      import('../pages').then((m) => m.IdentityConfirmationComponent),
  },
];
