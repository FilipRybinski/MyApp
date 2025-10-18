import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FeeTrackerComponent } from './fee-tracker.component';

describe('FeeTrackerComponent', () => {
  let component: FeeTrackerComponent;
  let fixture: ComponentFixture<FeeTrackerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeeTrackerComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FeeTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
