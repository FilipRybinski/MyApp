import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ContributorsToolsComponent } from './contributors-tools.component';

describe('ContributorsToolsComponent', () => {
  let component: ContributorsToolsComponent;
  let fixture: ComponentFixture<ContributorsToolsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContributorsToolsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ContributorsToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
