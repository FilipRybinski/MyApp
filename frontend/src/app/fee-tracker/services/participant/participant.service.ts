import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  BasicHttpResponse,
  HttpResponse,
} from '../../../../common/interfaces/http/httpResponse';
import { environment } from '../../../../environments/environment';
import { AttachFeeParticipantsAction } from '../../../../common/interfaces/participants/attachFeeParticipantsAction';
import { Purpose } from '../../../../common/interfaces/purpose/purpose';
import { Participant } from '../../../../common/interfaces/participants/participants';

@Injectable({
  providedIn: 'root',
})
export class ParticipantService {
  private http = inject(HttpClient);

  public createPurpose(
    body: AttachFeeParticipantsAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.FEE_TRACKER.ATTACH_CONTRIBUTOR,
      body
    );
  }

  public fetchParticipants(
    id: string
  ): Observable<HttpResponse<Participant[]>> {
    return this.http.get<HttpResponse<Participant[]>>(
      `${environment.URL.FEE_TRACKER.GET_FEE_PARTICIPANTS}?id=${id}`
    );
  }

  public markAsPaid(id: string): Observable<BasicHttpResponse> {
    return this.http.put<BasicHttpResponse>(
      environment.URL.FEE_TRACKER.MARK_AS_PAID,
      { id: id }
    );
  }
}
