import { TestBed } from '@angular/core/testing';

import { FeatureFlagService } from './feature-flag.service';
import * as SharedService from '../index';

describe('FeatureFlagService', () => {
  let service: FeatureFlagService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharedService.FeatureFlagService],
    });
    service = TestBed.inject(FeatureFlagService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
