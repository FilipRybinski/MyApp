import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  BasicHttpResponse,
  HttpResponse,
} from '../../../../common/interfaces/http/httpResponse';
import { Identity } from '../../../../common/interfaces/identity/identity';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { IdentitySignInAction } from '../../../../common/interfaces/httpActions/identitySignInAction';
import { IdentitySignUpAction } from '../../../../common/interfaces/httpActions/identitySignUpAction';
import { IdentityResetPasswordRequestAction } from '../../../../common/interfaces/httpActions/identityResetPasswordRequestAction';
import { IdentityActivationAction } from '../../../../common/interfaces/httpActions/identityActivationAction';
import { IdentityResetPasswordSubmissionAction } from '../../../../common/interfaces/httpActions/identityResetPasswordSubmissionAction';

@Injectable({
  providedIn: 'root',
})
export class IdentityService {
  private http = inject(HttpClient);

  public identitySignIn(
    body: IdentitySignInAction
  ): Observable<HttpResponse<Identity>> {
    return this.http.post<HttpResponse<Identity>>(
      environment.URL.IDENTITY.SIGN_IN,
      body
    );
  }

  public identitySignUp(
    body: IdentitySignUpAction
  ): Observable<HttpResponse<Identity>> {
    return this.http.post<HttpResponse<Identity>>(
      environment.URL.IDENTITY.SIGN_UP,
      body
    );
  }

  public identityResetPasswordRequest(
    body: IdentityResetPasswordRequestAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.IDENTITY.RESET_PASSWORD_REQUEST,
      body
    );
  }

  public identityActivation(
    body: IdentityActivationAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.IDENTITY.Activation,
      body
    );
  }

  public identityResetPasswordSubmission(
    body: IdentityResetPasswordSubmissionAction
  ): Observable<BasicHttpResponse> {
    return this.http.post<BasicHttpResponse>(
      environment.URL.IDENTITY.RESET_PASSWORD_SUBMISSION,
      body
    );
  }
}
