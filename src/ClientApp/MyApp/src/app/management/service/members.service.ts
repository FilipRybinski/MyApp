import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../../interfaces/account/user';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  constructor(private readonly _http: HttpClient) {}

  public getAvailableMembers(): Observable<User[]> {
    return this._http.get<User[]>(
      environment.URL.MEMBERS.GET_AVAILABLE_MEMBERS
    );
  }

  public getMyTeamMembers(body: string): Observable<User[]> {
    return this._http.get<User[]>(environment.URL.MEMBERS.GET_MY_TEAM_MEMBERS, {
      params: { id: body },
    });
  }

  public inviteMembers(body: { members: string[] }): Observable<null> {
    return this._http.post<null>(environment.URL.MEMBERS.INVITE_MEMBERS, body);
  }

  public removeMembers(body: { members: string[] }): Observable<null> {
    return this._http.post<null>(
      environment.URL.MEMBERS.REMOVE_MY_MEMBERS,
      body
    );
  }

  public findMembers(name: string): Observable<User[]> {
    return this._http.get<User[]>(
      environment.URL.MEMBERS.FIND_AVAILABLE_MEMBERS,
      {
        params: { name: name },
      }
    );
  }

  public downloadMembersPdfDocument(body: {
    members: string[];
  }): Observable<Blob> {
    return this._http.post(
      environment.URL.PRINT.PRINT_MEMBERS_PDF_DOCUMENT,
      body,
      { responseType: 'blob' }
    );
  }
}
