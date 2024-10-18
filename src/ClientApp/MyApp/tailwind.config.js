/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,ts}'],
  theme: {
    extend: {
      backgroundImage: {
        logo: "url('assets/logo/logo.svg')",
        polish_language: "url('assets/languages/polish.svg')",
        english_language: "url('assets/languages/english.svg')",
      },
    },
  },
  plugins: [],
};
