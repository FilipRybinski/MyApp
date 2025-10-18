import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarLanguageToolComponent } from './sidebar-language-tool.component';

describe('SidebarLanguageToolComponent', () => {
  let component: SidebarLanguageToolComponent;
  let fixture: ComponentFixture<SidebarLanguageToolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarLanguageToolComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarLanguageToolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
