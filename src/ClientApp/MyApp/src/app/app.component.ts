import { Component, OnDestroy } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { interval, Subscription } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnDestroy {
  title = 'MyApp';
  currentTime!: Date;
  private timerSubscription: Subscription;
  constructor() {
    this.timerSubscription = interval(1000).subscribe(() => (this.currentTime = new Date()));
  }

  ngOnDestroy(): void {
    this.timerSubscription.unsubscribe();
  }
}
