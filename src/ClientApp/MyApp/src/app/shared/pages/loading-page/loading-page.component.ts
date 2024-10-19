import { Component } from '@angular/core';

@Component({
  selector: 'app-loading-page',
  standalone: true,
  template: ` <div
    class="fixed inset-0 w-screen h-screen bg-white flex flex-col justify-center items-center">
    <div class="flex items-center">
      <div class="w-20 h-20 bg-logo bg-center bg-no-repeat bg-contain"></div>
      <span class="text-5xl font-semibold ">MyAppZone</span>
    </div>
    <div class="loader"></div>
  </div>`,
})
export class LoadingPageComponent {}
