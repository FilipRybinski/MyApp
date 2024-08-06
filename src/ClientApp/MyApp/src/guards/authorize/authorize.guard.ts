import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../service/auth/auth.service';

export const authorizeGuard: CanActivateFn = () => {
  const authService: AuthService = inject(AuthService);
  const router = inject(Router);
  if (!authService.isAuth()) {
    router.navigate(['/']).then(() => {
      return false;
    });
  }
  return true;
};
