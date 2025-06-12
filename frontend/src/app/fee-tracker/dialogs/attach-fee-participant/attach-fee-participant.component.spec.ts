import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AttachFeeParticipantComponent } from './attach-fee-participant.component';

describe('AttachFeeParticipantComponent', () => {
  let component: AttachFeeParticipantComponent;
  let fixture: ComponentFixture<AttachFeeParticipantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AttachFeeParticipantComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AttachFeeParticipantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
