import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarLogoutToolComponent } from './sidebar-logout-tool.component';

describe('SidebarLogoutToolComponent', () => {
  let component: SidebarLogoutToolComponent;
  let fixture: ComponentFixture<SidebarLogoutToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarLogoutToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarLogoutToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
