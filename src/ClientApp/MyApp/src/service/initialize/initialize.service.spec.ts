import { TestBed } from '@angular/core/testing';

import { InitializeService } from './initialize.service';
import { SharedModule } from '../../app/shared/shared.module';
import { provideHttpClient } from '@angular/common/http';
import { provideMockStore } from '@ngrx/state/testing';

describe('InitializeService', () => {
  let service: InitializeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule],
      providers: [provideHttpClient(), provideMockStore()],
    });
    service = TestBed.inject(InitializeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
