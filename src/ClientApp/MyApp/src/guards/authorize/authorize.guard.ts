import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { getHomeUrl } from '../../constants/routing/path';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs';
import { selectIsLoggedUserAuthorized } from '../../store/startup/startup.selectors';

export const authorizeGuard: CanActivateFn = () => {
  const router = inject(Router);
  const store = inject(Store);

  return store.select(selectIsLoggedUserAuthorized).pipe(
    tap(isAuth => {
      if (!isAuth) {
        router.navigate(getHomeUrl());
      }
    })
  );
};
