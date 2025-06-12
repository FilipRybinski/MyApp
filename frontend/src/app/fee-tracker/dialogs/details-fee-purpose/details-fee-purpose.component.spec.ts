import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DetailsFeePurposeComponent } from './details-fee-purpose.component';

describe('DetailsFeePurposeComponent', () => {
  let component: DetailsFeePurposeComponent;
  let fixture: ComponentFixture<DetailsFeePurposeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailsFeePurposeComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DetailsFeePurposeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
