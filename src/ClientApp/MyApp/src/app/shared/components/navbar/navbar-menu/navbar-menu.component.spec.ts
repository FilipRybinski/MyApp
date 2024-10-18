import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarMenuComponent } from './navbar-menu.component';
import { SharedModule } from '../../../shared.module';
import { RouterModule } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { initialStartupState } from '../../../../../state/startup/startup.reducer';
import { selectIsLoggedUserAuthorized } from '../../../../../state/startup/startup.selectors';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { TranslateModule } from '@ngx-translate/core';

describe('NavbarMenuComponent', () => {
  let component: NavbarMenuComponent;
  let fixture: ComponentFixture<NavbarMenuComponent>;
  let mockStore;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NavbarMenuComponent],
      imports: [
        SharedModule,
        RouterModule.forRoot([]),
        TranslateModule.forRoot(),
      ],
      providers: [
        provideHttpClient(),
        provideMockStore({ initialState: initialStartupState }),
      ],
    }).compileComponents();

    mockStore = TestBed.inject(MockStore);
    mockStore.overrideSelector(selectIsLoggedUserAuthorized, false);
    fixture = TestBed.createComponent(NavbarMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
