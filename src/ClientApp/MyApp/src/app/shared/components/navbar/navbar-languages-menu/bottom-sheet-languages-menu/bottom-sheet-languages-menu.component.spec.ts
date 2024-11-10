import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottomSheetLanguagesMenuComponent } from './bottom-sheet-languages-menu.component';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../../../../shared.module';
import { SsrCookieService } from 'ngx-cookie-service-ssr';

describe('BottomSheetLanguagesMenuComponent', () => {
  let component: BottomSheetLanguagesMenuComponent;
  let fixture: ComponentFixture<BottomSheetLanguagesMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BottomSheetLanguagesMenuComponent],
      imports: [TranslateModule.forRoot(), SharedModule],
      providers: [SsrCookieService],
    }).compileComponents();

    fixture = TestBed.createComponent(BottomSheetLanguagesMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
