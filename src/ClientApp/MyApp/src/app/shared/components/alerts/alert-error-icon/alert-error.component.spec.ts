import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertErrorComponent } from './alert-error-icon.component';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule } from '@ngx-translate/core';

describe('AlertErrorIconComponent', () => {
  let component: AlertErrorComponent;
  let fixture: ComponentFixture<AlertErrorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertErrorComponent, MatIcon, TranslateModule.forRoot()],
      providers: [{ provide: MAT_SNACK_BAR_DATA, useValue: 'Test' }],
    }).compileComponents();

    fixture = TestBed.createComponent(AlertErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
