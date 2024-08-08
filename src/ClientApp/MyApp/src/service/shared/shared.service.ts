import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private readonly http: HttpClient) {}

  public logout(): Observable<boolean> {
    return this.http.get<boolean>(environment.URL.USERS.LOGOUT);
  }
}
