import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IdentityResetPasswordComponent } from './identity-reset-password.component';

describe('IdentityResetPasswordComponent', () => {
  let component: IdentityResetPasswordComponent;
  let fixture: ComponentFixture<IdentityResetPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentityResetPasswordComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(IdentityResetPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
