import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyTeamComponent } from './my-team.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { SharedModule } from '../../../shared/shared.module';

describe('MyTeamComponent', () => {
  let component: MyTeamComponent;
  let fixture: ComponentFixture<MyTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MyTeamComponent],
      imports: [HttpClientTestingModule, SharedModule],
    }).compileComponents();

    fixture = TestBed.createComponent(MyTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
