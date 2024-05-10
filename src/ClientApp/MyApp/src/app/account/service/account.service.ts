import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { URL } from '../../../constants/urls/url';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private _http: HttpClient) {}

  public test(): Observable<boolean> {
    return this._http.post<boolean>(
      URL.SIGN_IN,
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
