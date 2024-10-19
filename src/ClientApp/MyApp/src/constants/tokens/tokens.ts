import { InjectionToken } from '@angular/core';

const authToken = 'AUTHORIZATION_COOKIE';

export const AUTHORIZATION_COOKIE = new InjectionToken<string>(authToken);
