import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertSuccessComponent } from './alert-success-icon.component';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule } from '@ngx-translate/core';

describe('AlertSuccessIconComponent', () => {
  let component: AlertSuccessComponent;
  let fixture: ComponentFixture<AlertSuccessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertSuccessComponent, MatIcon, TranslateModule.forRoot()],
      providers: [{ provide: MAT_SNACK_BAR_DATA, useValue: 'Test' }],
    }).compileComponents();

    fixture = TestBed.createComponent(AlertSuccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
