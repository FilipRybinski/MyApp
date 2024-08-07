import { TestBed } from '@angular/core/testing';

import { AccountService } from './account.service';
import { SharedModule } from '../../../shared/shared.module';

describe('AccountService', () => {
  let service: AccountService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule],
    });
    service = TestBed.inject(AccountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
