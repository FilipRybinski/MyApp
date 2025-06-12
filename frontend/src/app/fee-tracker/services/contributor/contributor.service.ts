import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  BasicHttpResponse,
  HttpResponse,
} from '../../../../common/interfaces/http/httpResponse';
import { Identity } from '../../../../common/interfaces/identity/identity';
import { environment } from '../../../../environments/environment';
import { CreateContributorAction } from '../../../../common/interfaces/contributor/createContributorAction';
import { Contributor } from '../../../../common/interfaces/contributor/contributor';

@Injectable({
  providedIn: 'root',
})
export class ContributorService {
  private http = inject(HttpClient);
  public contributors: WritableSignal<Contributor[]> = signal<Contributor[]>(
    []
  );

  public createContributor(
    body: CreateContributorAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.FEE_TRACKER.ADD_FEE_CONTRIBUTOR,
      body
    );
  }

  public fetchContributors(): Observable<HttpResponse<Contributor[]>> {
    return this.http.get<HttpResponse<Contributor[]>>(
      environment.URL.FEE_TRACKER.GET_FEE_CONTRIBUTOR
    );
  }
}
