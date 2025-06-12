import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  template: `
    <div class="min-h-screen w-full px-4 py-10 ">
      <div class="max-w-4xl mx-auto">
        <h1 class="text-4xl font-bold text-green-400 mb-6">
          Welcome to MyAppZone 🎉
        </h1>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-2">Introduction 🌟</h2>
          <p class=" mb-4">
            Welcome to <strong>MyApp</strong>! Our project is currently under
            development, but we already have some exciting features ready to
            use:
          </p>
          <ul class="list-disc list-inside space-y-1 ">
            <li>Landing Page 🌐</li>
            <li>Login 🔐</li>
            <li>Registration 📝</li>
            <li>Translations 🌍</li>
          </ul>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-2">About the Project 📋</h2>
          <p class=" mb-4">
            <strong>MyApp</strong> is an innovative application that allows you
            to create groups of people and collect data regarding contributions.
            You can link individuals to registered users, and soon we’ll support
            integration with events (like from PLP). Users will be able to send
            participation confirmation links, view contribution statistics, and
            generate insightful charts.
          </p>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-2">
            Features in Development 🛠️
          </h2>
          <ul class="list-disc list-inside space-y-1 ">
            <li>Creating Groups of People 👥</li>
            <li>Collecting Contribution Data 💰</li>
            <li>Linking People with Created Users 🔗</li>
            <li>Event Integration 📅</li>
            <li>Fetching Event Lists from Various Sites 🌐</li>
            <li>Sending Links for Event Participation Confirmation 📩</li>
            <li>Contribution Statistics Panel 📊</li>
            <li>Charts Based on Selected Group or Collection 📈</li>
          </ul>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-2">Getting Started 🚀</h2>
          <ol class="list-decimal list-inside space-y-1 ">
            <li>Register on our website.</li>
            <li>Log in to your account.</li>
            <li>Create groups and collect data.</li>
          </ol>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-2">Contact 📧</h2>
          <p>
            If you have any questions or suggestions, contact us at
            <a
              href="mailto:email@example.com"
              class="text-green-400 underline hover:text-green-300"
              >support&#64;myappzone.pl</a
            >.
          </p>
        </section>

        <footer class="mt-12 text-sm text-center">
          &copy; {{ currentYear }} MyAppZone. All rights reserved.
        </footer>
      </div>
    </div>
  `,
})
export class HomeComponent {
  public currentYear = new Date().getFullYear();
}
