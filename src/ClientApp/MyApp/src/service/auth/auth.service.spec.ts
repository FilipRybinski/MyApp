import { TestBed } from '@angular/core/testing';

import { AuthService } from './auth.service';
import * as SharedService from '../../app/shared/service';

describe('AuthService', () => {
  let service: AuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharedService.AuthService],
    });
    service = TestBed.inject(AuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
