import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarThemeToolComponent } from './sidebar-theme-tool.component';

describe('SidebarThemeToolComponent', () => {
  let component: SidebarThemeToolComponent;
  let fixture: ComponentFixture<SidebarThemeToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarThemeToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarThemeToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
