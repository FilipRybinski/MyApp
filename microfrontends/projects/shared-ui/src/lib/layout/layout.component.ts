import {Component, signal} from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'lib-layout',
  imports: [
    MatSidenavModule,
    MatButtonModule,
    MatIconModule
  ],
  template:`
    <mat-drawer-container hasBackdrop="true">
      <mat-drawer #drawer mode="over">
        <ng-content select="side-menu">
          <div>
            <button mat-raised-button (click)="drawer.toggle()">
              <ng-content select="side-menu-icon"></ng-content>
            </button>
          </div>
          <div>
            <ng-content select="side-menu-content"></ng-content>
          </div>
        </ng-content>
      </mat-drawer>
      <mat-drawer-content>
        <div>
          <button mat-raised-button (click)="drawer.toggle()">
            <ng-content select="side-menu-icon"></ng-content>
          </button>
        </div>
        <div></div>

      </mat-drawer-content>
    </mat-drawer-container>
  `,
})
export class LayoutComponent {

}
