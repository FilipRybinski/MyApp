import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ContributorsSidebarComponent } from './contributors-sidebar.component';

describe('ContributorsSidebarComponent', () => {
  let component: ContributorsSidebarComponent;
  let fixture: ComponentFixture<ContributorsSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContributorsSidebarComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ContributorsSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
