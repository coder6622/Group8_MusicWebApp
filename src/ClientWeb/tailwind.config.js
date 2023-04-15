/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{js,jsx,ts,tsx}'],
  theme: {
    extend: {},
    colors: {
      white: 'var(--color-white)',
      red: 'var(--color-red)',
      gray: 'var(--color-gray)',
      black: 'var(--color-black)',
      primary: 'var(--color-primary)',
      accent: 'var(--color-accent)',
      active: 'var(--color-active)',
      text: 'var(--color-text)',
      hoverText: 'var(--color-hover-text)',
      hoverSong: 'var(--color-hover-song)',
      hoverIcon: 'var(--color-hover-icon)',
    },
    fontFamily: {
      roboto: ['Roboto', 'sans-serif'],
    },
  },

  plugins: [],
};
