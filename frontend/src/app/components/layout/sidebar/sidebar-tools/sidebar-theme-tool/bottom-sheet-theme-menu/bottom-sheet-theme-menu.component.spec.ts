import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BottomSheetThemeMenuComponent } from './bottom-sheet-theme-menu.component';

describe('BottomSheetThemeMenuComponent', () => {
  let component: BottomSheetThemeMenuComponent;
  let fixture: ComponentFixture<BottomSheetThemeMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BottomSheetThemeMenuComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(BottomSheetThemeMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
