import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IdentitySignUpComponent } from './identity-sign-up.component';

describe('IdentitySignUpComponent', () => {
  let component: IdentitySignUpComponent;
  let fixture: ComponentFixture<IdentitySignUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentitySignUpComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(IdentitySignUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
