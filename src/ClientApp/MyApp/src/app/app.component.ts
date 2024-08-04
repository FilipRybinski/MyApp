import { AfterViewInit, Component, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements AfterViewInit {
  title = 'MyAppZone';
  private readonly loadingScreen: string = 'loading-screen';

  constructor(private readonly renderer: Renderer2) {}

  public ngAfterViewInit(): void {
    const element = document.getElementById(this.loadingScreen);
    this.renderer.removeChild(element!.parentElement, element);
  }
}
