import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IdentityResetPasswordRequestComponent } from './identity-reset-password-request.component';

describe('IdentityResetPasswordRequestComponent', () => {
  let component: IdentityResetPasswordRequestComponent;
  let fixture: ComponentFixture<IdentityResetPasswordRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentityResetPasswordRequestComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(IdentityResetPasswordRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
