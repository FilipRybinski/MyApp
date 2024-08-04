import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import * as SharedService from '../../app/shared/service';

export const authorizeGuard: CanActivateFn = () => {
  const authService: SharedService.AuthService = inject(
    SharedService.AuthService
  );
  const router = inject(Router);
  if (!authService.isAuth()) {
    router.navigate(['/']).then(() => {
      return false;
    });
  }
  return true;
};
