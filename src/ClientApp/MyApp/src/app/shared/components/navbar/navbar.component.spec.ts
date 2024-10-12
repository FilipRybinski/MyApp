import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarComponent } from './navbar.component';
import { SharedModule } from '../../shared.module';
import { RouterModule } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { initialStartupState } from '../../../../state/startup/startup.reducer';
import { selectIsLoggedUserAuthorized } from '../../../../state/startup/startup.selectors';

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;
  let mockStore;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NavbarComponent],
      imports: [SharedModule, RouterModule.forRoot([])],
      providers: [
        provideHttpClient(),
        provideMockStore({ initialState: initialStartupState }),
      ],
    }).compileComponents();

    mockStore = TestBed.inject(MockStore);
    mockStore.overrideSelector(selectIsLoggedUserAuthorized, false);
    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
