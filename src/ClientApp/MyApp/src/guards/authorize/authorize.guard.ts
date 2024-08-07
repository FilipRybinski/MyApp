import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { getHomeUrl } from '../../constants/routing/path';
import { AuthService } from '../../service/auth/auth.service';

export const authorizeGuard: CanActivateFn = () => {
  const router = inject(Router);
  const authService: AuthService = inject(AuthService);

  if (authService.isAuth()) {
    return true;
  }
  router.navigate(getHomeUrl());
  return false;
};
