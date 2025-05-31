import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { IDENTITY_PARAMS } from '../../routes/identity.routes';
import { IdentityService } from '../../services/identity/identity.service';

@Component({
  selector: 'app-identity-confirmation',
  imports: [CommonModule],
  template: `TEST2`,
})
export class IdentityConfirmationComponent implements OnInit {
  private readonly activatedRoute = inject(ActivatedRoute);
  private readonly identityService = inject(IdentityService);

  private id: string | null = null;
  private token: string | null = null;

  public ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.IDENTITY
    );
    this.token = this.activatedRoute.snapshot.paramMap.get(
      IDENTITY_PARAMS.TOKEN
    );
  }
}
