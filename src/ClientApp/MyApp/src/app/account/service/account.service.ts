import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { SignIn } from '../../../interfaces/signIn';
import { SignUp } from '../../../interfaces/signUp';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private _http: HttpClient) {}

  public signIn(body: SignIn): Observable<boolean> {
    return this._http.post<boolean>(environment.URL.ACCOUNT.SIGN_IN, body);
  }

  public signUp(body: SignUp): Observable<boolean> {
    return this._http.post<boolean>(environment.URL.ACCOUNT.SIGN_UP, body);
  }
}
