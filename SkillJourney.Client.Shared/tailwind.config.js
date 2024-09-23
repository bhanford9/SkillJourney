/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['../../**/*.{razor,html,cshtml,js}'],
  safelist: [
    // {
    //   pattern: /./,
    // }
  ],
  theme: {
    extend: {
      colors: {
        primary: '#776be7',
        'primary-hover': '#776be70f',
        'default-hover': '#adadb10f',
        'text-primary': '#ffffffb2',
        surface: '#373740',
        background: '#32333d'
      },
      fontFamily: {
        serif: ['Roboto', 'Helvetica', 'Arial', 'sans-serif']
      }
    },
  },
  plugins: [],
}

