import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FeeTrackerSidebarComponent } from './fee-tracker-sidebar.component';

describe('FeeTrackerSidebarComponent', () => {
  let component: FeeTrackerSidebarComponent;
  let fixture: ComponentFixture<FeeTrackerSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeeTrackerSidebarComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FeeTrackerSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
