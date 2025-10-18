import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarToolsComponent } from './sidebar-tools.component';

describe('SidebarToolsComponent', () => {
  let component: SidebarToolsComponent;
  let fixture: ComponentFixture<SidebarToolsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarToolsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
