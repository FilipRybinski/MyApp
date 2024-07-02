import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SignIn } from '../../../interfaces/account/signIn';
import { SignUp } from '../../../interfaces/account/signUp';
import { User } from '../../../interfaces/account/user';
import { FeatureFlags } from '../../../interfaces/featureFlags/featureFlags';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private _http: HttpClient) {}

  public signIn(body: SignIn): Observable<User> {
    return this._http.post<User>(environment.URL.ACCOUNT.SIGN_IN, body);
  }

  public signUp(body: SignUp): Observable<boolean> {
    return this._http.post<boolean>(environment.URL.ACCOUNT.SIGN_UP, body);
  }

  public getFeatureFlags(): Observable<FeatureFlags> {
    return this._http.get<FeatureFlags>(environment.URL.FEATURE_FLAGS);
  }
}
