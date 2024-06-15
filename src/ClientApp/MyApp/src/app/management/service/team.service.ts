import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Team } from '../../../interfaces/team/team';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  constructor(private readonly _http: HttpClient) {}

  public getMyTeam(): Observable<Team> {
    return this._http.get<Team>(environment.URL.TEAM.GET_MY_TEAM);
  }

  public updateMyTeam(body: Team): Observable<Team> {
    return this._http.put<Team>(environment.URL.TEAM.UPDATE_MY_TEAM, body);
  }

  public createTeam(body: Team): Observable<null> {
    return this._http.post<null>(environment.URL.TEAM.CREATE_TEAM, body);
  }
}
