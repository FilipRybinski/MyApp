import { Component, inject } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { BottomSheetLanguagesMenuComponent } from './bottom-sheet-languages-menu/bottom-sheet-languages-menu.component';

@Component({
  selector: 'app-navbar-languages-menu',
  templateUrl: './navbar-languages-menu.component.html',
})
export class NavbarLanguagesMenuComponent {
  private readonly bottomSheet = inject(MatBottomSheet);

  public openBottomSheet(): void {
    this.bottomSheet.open(BottomSheetLanguagesMenuComponent);
  }
}
