import { ComponentFixture, TestBed } from '@angular/core/testing';
import { IdentityConfirmationComponent } from './identity-confirmation.component';

describe('IdentityConfirmationComponent', () => {
  let component: IdentityConfirmationComponent;
  let fixture: ComponentFixture<IdentityConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentityConfirmationComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(IdentityConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
