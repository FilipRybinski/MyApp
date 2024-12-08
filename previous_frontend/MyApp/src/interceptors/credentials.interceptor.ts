import { HttpInterceptorFn } from '@angular/common/http';
import { inject, PLATFORM_ID } from '@angular/core';
import { isPlatformServer } from '@angular/common';
import { SsrCookieService } from 'ngx-cookie-service-ssr';

const withCredentialsHeader = 'Cookie';

export const credentialsInterceptor: HttpInterceptorFn = (req, next) => {
  const platform = inject(PLATFORM_ID);
  let request;

  if (isPlatformServer(platform)) {
    const cookieService = inject(SsrCookieService);
    request = req.clone({
      headers: req.headers.append(
        withCredentialsHeader,
        withCredentialsSsr(cookieService.getAll())
      ),
    });
  } else {
    request = req.clone({ withCredentials: true });
  }

  return next(request);
};

const withCredentialsSsr = (cookies: object): string => {
  return Object.entries(cookies)
    .map(([key, value]) => `${key}=${value}`)
    .join('; ');
};
