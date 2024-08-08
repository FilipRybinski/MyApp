import { TestBed } from '@angular/core/testing';

import { InitializeService } from './initialize.service';
import { SharedModule } from '../../app/shared/shared.module';

describe('InitializeService', () => {
  let service: InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule],
    });
    service = TestBed.inject(InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
