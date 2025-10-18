import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarInfoToolComponent } from './sidebar-info-tool.component';

describe('SidebarInfoToolComponent', () => {
  let component: SidebarInfoToolComponent;
  let fixture: ComponentFixture<SidebarInfoToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarInfoToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarInfoToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
