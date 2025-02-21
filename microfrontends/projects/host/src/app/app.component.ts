import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {SharedUiComponent} from '../../../shared-ui/src/lib/shared-ui.component';

@Component({
  selector: 'app-host-root',
  imports: [RouterOutlet,SharedUiComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'host';
}
