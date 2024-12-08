import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { getHomeUrl } from '../../constants/routing/path';
import { AppStore } from '../../store/app.store';

export const authorizeGuard: CanActivateFn = () => {
  const router = inject(Router);
  const appStore = inject(AppStore);
  if (!appStore.loggedInUser.isAuth()) {
    router.navigate(getHomeUrl());
    return false;
  }
  return true;
};
