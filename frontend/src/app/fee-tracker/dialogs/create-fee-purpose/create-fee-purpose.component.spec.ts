import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateFeePurposeComponent } from './create-fee-purpose.component';

describe('CreateFeePurposeComponent', () => {
  let component: CreateFeePurposeComponent;
  let fixture: ComponentFixture<CreateFeePurposeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateFeePurposeComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateFeePurposeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
