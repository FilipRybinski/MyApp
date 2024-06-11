import { TestBed } from '@angular/core/testing';

import { InitializeService } from './initialize.service';
import { HttpClientModule } from '@angular/common/http';

describe('InitializeService', () => {
  let service: InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientModule] });
    service = TestBed.inject(InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
