import { TestBed } from '@angular/core/testing';

import { HttpClientModule } from '@angular/common/http';
import * as SharedService from '../index';

describe('InitializeService', () => {
  let service: SharedService.InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [
        SharedService.InitializeService,
        SharedService.FeatureFlagService,
        SharedService.AuthService,
      ],
    });
    service = TestBed.inject(SharedService.InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
