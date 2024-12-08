import { TestBed } from '@angular/core/testing';

import { AccountService } from './account.service';
import { AccountModule } from '../../account.module';
import { provideHttpClient } from '@angular/common/http';

describe('AccountService', () => {
  let service: AccountService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AccountModule],
      providers: [provideHttpClient()],
    });
    service = TestBed.inject(AccountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
