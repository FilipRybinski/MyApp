import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarLanguagesMenuComponent } from './navbar-languages-menu.component';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../../../shared.module';

describe('NavbarLanguagesMenuComponent', () => {
  let component: NavbarLanguagesMenuComponent;
  let fixture: ComponentFixture<NavbarLanguagesMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NavbarLanguagesMenuComponent],
      imports: [TranslateModule.forRoot(), SharedModule],
    }).compileComponents();

    fixture = TestBed.createComponent(NavbarLanguagesMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
