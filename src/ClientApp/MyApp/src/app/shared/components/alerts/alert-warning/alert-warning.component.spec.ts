import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertWarningComponent } from './alert-warning-icon.component';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { MatIcon } from '@angular/material/icon';

describe('AlertWarningIconComponent', () => {
  let component: AlertWarningComponent;
  let fixture: ComponentFixture<AlertWarningComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertWarningComponent, MatIcon],
      providers: [{ provide: MAT_SNACK_BAR_DATA, useValue: 'Test' }],
    }).compileComponents();

    fixture = TestBed.createComponent(AlertWarningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
