import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  BasicHttpResponse,
  HttpResponse,
} from '../../../../common/interfaces/http/httpResponse';
import { environment } from '../../../../environments/environment';
import { CreatePurposeAction } from '../../../../common/interfaces/purpose/createPurposeAction';
import { Purpose } from '../../../../common/interfaces/purpose/purpose';

@Injectable({
  providedIn: 'root',
})
export class PurposeService {
  private http = inject(HttpClient);

  public createPurpose(
    body: CreatePurposeAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.FEE_TRACKER.ADD_FEE_PURPOSE,
      body
    );
  }

  public fetchPurposes(): Observable<HttpResponse<Purpose[]>> {
    return this.http.get<HttpResponse<Purpose[]>>(
      environment.URL.FEE_TRACKER.GET_FEE_PURPOSE
    );
  }

  public markAsCompleted(id: string): Observable<BasicHttpResponse> {
    return this.http.put<BasicHttpResponse>(
      environment.URL.FEE_TRACKER.MARK_AS_COMPLETED,
      { id }
    );
  }

  public deletePurpose(id: string): Observable<BasicHttpResponse> {
    return this.http.delete<BasicHttpResponse>(
      `${environment.URL.FEE_TRACKER.DELETE_FEE_PURPOSE}?id=${id}`
    );
  }
}
