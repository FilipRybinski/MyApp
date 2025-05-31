import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarHomeToolComponent } from './sidebar-home-tool.component';

describe('SidebarHomeToolComponent', () => {
  let component: SidebarHomeToolComponent;
  let fixture: ComponentFixture<SidebarHomeToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarHomeToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarHomeToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
