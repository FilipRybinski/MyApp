import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IdentitySignInComponent } from './identity-sign-in.component';

describe('IdentitySignInComponent', () => {
  let component: IdentitySignInComponent;
  let fixture: ComponentFixture<IdentitySignInComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentitySignInComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(IdentitySignInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
