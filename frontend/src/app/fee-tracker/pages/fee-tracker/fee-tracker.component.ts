import { Component, signal, WritableSignal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContributorsSidebarComponent } from '../../components/contributors-sidebar/contributors-sidebar.component';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-fee-tracker',
  imports: [CommonModule, ContributorsSidebarComponent, MatIconModule],
  template: ` <app-contributors-sidebar />`,
})
export class FeeTrackerComponent {}
