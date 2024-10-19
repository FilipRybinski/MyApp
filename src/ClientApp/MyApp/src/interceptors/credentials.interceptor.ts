import { HttpInterceptorFn } from '@angular/common/http';
import { inject, PLATFORM_ID } from '@angular/core';
import { AUTHORIZATION_COOKIE } from '../constants/tokens/tokens';
import { isPlatformServer } from '@angular/common';

export const credentialsInterceptor: HttpInterceptorFn = (req, next) => {
  const platform = inject(PLATFORM_ID);
  let headers = req.headers;

  if (isPlatformServer(platform)) {
    const ssrAuthCookie = inject(AUTHORIZATION_COOKIE, { optional: true });
    headers = ssrAuthCookie ? headers.append('Cookie', ssrAuthCookie) : headers;
  }

  const request = req.clone({ headers, withCredentials: true });
  return next(request);
};
