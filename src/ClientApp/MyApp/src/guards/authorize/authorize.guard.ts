import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { getHomeUrl } from '../../constants/routing/path';
import { tap } from 'rxjs';
import { selectIsLoggedUserAuthorized } from '../../state/startup/startup.selectors';
import { Store } from '@ngrx/store';

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
