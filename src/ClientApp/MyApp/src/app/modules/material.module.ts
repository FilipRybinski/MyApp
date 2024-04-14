import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
  declarations: [],
  imports: [CommonModule, MatIconModule, MatButtonModule, MatMenuModule],
  exports: [MatIconModule, MatButtonModule, MatMenuModule],
})
export class MaterialModule {}
