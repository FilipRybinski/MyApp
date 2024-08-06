import { TestBed } from '@angular/core/testing';

import { HttpClientModule } from '@angular/common/http';
import { InitializeService } from './initialize.service';
import { FeatureFlagService } from '../featureFlag/feature-flag.service';
import { AuthService } from '../auth/auth.service';

describe('InitializeService', () => {
  let service: InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [InitializeService, FeatureFlagService, AuthService],
    });
    service = TestBed.inject(InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
