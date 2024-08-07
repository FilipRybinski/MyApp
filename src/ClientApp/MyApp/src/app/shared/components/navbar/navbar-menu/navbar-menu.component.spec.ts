import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarMenuComponent } from './navbar-menu.component';
import { SharedModule } from '../../../shared.module';
import { AuthService } from '../../../../../service/auth/auth.service';
import { RouterModule } from '@angular/router';

describe('NavbarMenuComponent', () => {
  let component: NavbarMenuComponent;
  let fixture: ComponentFixture<NavbarMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NavbarMenuComponent],
      imports: [SharedModule, RouterModule.forRoot([])],
      providers: [AuthService],
    }).compileComponents();

    fixture = TestBed.createComponent(NavbarMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
