import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarAvatarComponent } from './sidebar-avatar.component';

describe('SidebarAvatarComponent', () => {
  let component: SidebarAvatarComponent;
  let fixture: ComponentFixture<SidebarAvatarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarAvatarComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarAvatarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
