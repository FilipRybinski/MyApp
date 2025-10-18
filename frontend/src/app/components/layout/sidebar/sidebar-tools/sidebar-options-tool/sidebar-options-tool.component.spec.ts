import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarOptionsToolComponent } from './sidebar-options-tool.component';

describe('SidebarOptionsToolComponent', () => {
  let component: SidebarOptionsToolComponent;
  let fixture: ComponentFixture<SidebarOptionsToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarOptionsToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarOptionsToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
