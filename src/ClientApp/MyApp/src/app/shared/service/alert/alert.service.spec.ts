import { TestBed } from '@angular/core/testing';

import { AlertService } from './alert.service';

import { SharedModule } from '../../shared.module';

describe('AlertService', () => {
  let service: AlertService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule],
    });
    service = TestBed.inject(AlertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
