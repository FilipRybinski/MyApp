import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { SignIn } from '../../../../interfaces/account/signIn';
import { SignUp } from '../../../../interfaces/account/signUp';
import { User } from '../../../../interfaces/account/user';
import { Response } from '../../../../interfaces/response/Response';

@Injectable()
export class AccountService {
  private _http = inject(HttpClient);

  public signIn(body: SignIn): Observable<Response<User>> {
    return this._http.post<Response<User>>(environment.URL.USERS.SIGN_IN, body);
  }

  public signUp(body: SignUp): Observable<Response<User>> {
    return this._http.post<Response<User>>(environment.URL.USERS.SIGN_UP, body);
  }
}
