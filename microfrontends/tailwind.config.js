/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './apps/**/*.{html,ts}',
    './libs/**/*.{html,ts}',
  ],
  theme: {
    extend: {
      colors:{
        background: {
          DEFAULT: '#131617',
          light: '#16191b'
        },
        green:{
          DEFAULT: '#057d52',
          light: '#339f4a'
        }
      }
    },
  },
  plugins: [],
}

