import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Response } from '../../interfaces/response/Response';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private readonly http = inject(HttpClient);

  public logout(): Observable<Response<null>> {
    return this.http.get<Response<null>>(environment.URL.USERS.LOGOUT);
  }
}
