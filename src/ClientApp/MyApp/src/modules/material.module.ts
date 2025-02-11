import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTreeModule } from '@angular/material/tree';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';

const dependencies = [
  CommonModule,
  MatIconModule,
  MatButtonModule,
  MatMenuModule,
  FormsModule,
  MatFormFieldModule,
  MatInputModule,
  MatTableModule,
  MatListModule,
  MatDividerModule,
  MatSlideToggleModule,
  MatProgressSpinnerModule,
  MatAutocompleteModule,
  MatProgressBarModule,
  MatTooltipModule,
  MatSidenavModule,
  MatTreeModule,
  MatBottomSheetModule,
];

@NgModule({
  declarations: [],
  imports: [...dependencies],
  exports: [...dependencies],
})
export class MaterialModule {}
