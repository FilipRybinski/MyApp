import { TestBed } from '@angular/core/testing';

import { SharedService } from './shared.service';
import { SharedModule } from '../../app/shared/shared.module';
import { provideHttpClient } from '@angular/common/http';

describe('SharedService', () => {
  let service: SharedService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule],
      providers: [provideHttpClient()],
    });
    service = TestBed.inject(SharedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
