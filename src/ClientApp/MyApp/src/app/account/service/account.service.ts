import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SignIn } from '../../../interfaces/account/signIn';
import { SignUp } from '../../../interfaces/account/signUp';
import { User } from '../../../interfaces/account/user';
import { StoreService } from '../../shared/service/store.service';
import { ActionResult } from '../../../interfaces/account/actionResult';
import { FeatureFlags } from '../../../interfaces/featureFlags/featureFlags';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(
    private _http: HttpClient,
    private readonly _storeService: StoreService
  ) {}

  public signIn(body: SignIn): Observable<User> {
    return this._http.post<User>(environment.URL.ACCOUNT.SIGN_IN, body);
  }

  public signUp(body: SignUp): Observable<boolean> {
    return this._http.post<boolean>(environment.URL.ACCOUNT.SIGN_UP, body);
  }

  public logOut(): Observable<ActionResult> {
    return this._http.get<ActionResult>(environment.URL.ACCOUNT.LOG_OUT);
  }

  public getMyAccount(): Observable<User> {
    return this._http.get<User>(environment.URL.ACCOUNT.GET_MY_ACCOUNT);
  }

  public getFeatureFlags(): Observable<FeatureFlags> {
    return this._http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS);
  }
}
