/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,ts}'],
  theme: {
    extend: {
      backgroundImage: {
        logo: "url('assets/logo/logo.svg')",
      },
    },
  },
  plugins: [],
};
