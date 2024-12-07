import { TestBed } from '@angular/core/testing';

import { InitializeService } from './initialize.service';
import { SharedModule } from '../../app/shared/shared.module';
import { provideHttpClient } from '@angular/common/http';
import { SsrCookieService } from 'ngx-cookie-service-ssr';
import { TranslateModule } from '@ngx-translate/core';

describe('InitializeService', () => {
  let service: InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule, TranslateModule.forRoot()],
      providers: [provideHttpClient(), SsrCookieService],
    });
    service = TestBed.inject(InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
