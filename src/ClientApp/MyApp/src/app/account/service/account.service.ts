import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private _http: HttpClient) {}

  public test(): Observable<boolean> {
    return this._http.post<boolean>(
      'http://localhost:5095/Users/SignIn',
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
