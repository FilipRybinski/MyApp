import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private _http: HttpClient) {}

  public SignIn(): Observable<boolean> {
    return this._http.post<boolean>(
      environment.URL.SIGN_IN,
      {
        username: 'string',
        password: 'string',
      },
      {
        withCredentials: true,
      }
    );
  }
}
