export const PATH = {
  HOME: 'home',
  ACCOUNT: 'account',
  SIGN_IN: 'signin',
  SIGN_UP: 'signup',
  SETTINGS: 'settings',
  MANAGEMENT: 'management',
  DASHBOARD: 'dashboard',
  FINANCE: 'finance',
  MARKETPLACE: 'marketplace',
  PAGE_NOT_FOUND: '**',
};

export const getHomeUrl = (): string[] => {
  return [PATH.HOME];
};
