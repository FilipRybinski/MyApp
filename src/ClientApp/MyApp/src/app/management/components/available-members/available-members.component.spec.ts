import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableMembersComponent } from './available-members.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { SharedModule } from '../../../shared/shared.module';

describe('AvailableMembersComponent', () => {
  let component: AvailableMembersComponent;
  let fixture: ComponentFixture<AvailableMembersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AvailableMembersComponent],
      imports: [HttpClientTestingModule, SharedModule],
    }).compileComponents();

    fixture = TestBed.createComponent(AvailableMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
