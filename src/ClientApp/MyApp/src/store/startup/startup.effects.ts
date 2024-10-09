import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, Observable, switchMap } from 'rxjs';
import { User } from '../../interfaces/account/user';
import { environment } from '../../environments/environment';
import { FeatureFlags } from '../../interfaces/featureFlags/featureFlags';
import { HttpClient } from '@angular/common/http';
import {
  attachFeatureFlags,
  authorizeUser,
  loadInitialData,
} from './startup.action';

@Injectable()
export class StartupEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly http: HttpClient
  ) {}

  loadLoggedInUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadInitialData),
      switchMap(() =>
        this.isAuthorized().pipe(
          map(response => authorizeUser({ user: response }))
        )
      )
    )
  );

  featureFlags$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadInitialData),
      switchMap(() =>
        this.getFeatureFlags().pipe(
          map(response => attachFeatureFlags({ featureFlags: response }))
        )
      )
    )
  );

  private isAuthorized(): Observable<User> {
    return this.http.get<User>(environment.URL.USERS.IS_AUTHORIZED);
  }

  private getFeatureFlags(): Observable<FeatureFlags> {
    return this.http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS);
  }
}
