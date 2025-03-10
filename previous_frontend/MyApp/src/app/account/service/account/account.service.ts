import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { SignIn } from '../../../../interfaces/account/signIn';
import { SignUp } from '../../../../interfaces/account/signUp';
import { User } from '../../../../interfaces/account/user';

@Injectable()
export class AccountService {
  private _http = inject(HttpClient);

  public signIn(body: SignIn): Observable<User> {
    return this._http.post<User>(environment.URL.USERS.SIGN_IN, body);
  }

  public signUp(body: SignUp): Observable<boolean> {
    return this._http.post<boolean>(environment.URL.USERS.SIGN_UP, body);
  }
}
