module.exports = {
    content: ['./**/*.{razor,html}'],
    darkMode: 'class',
    theme: {
        extend: {},
    },
    plugins: [
        require("tailwindcss-animate"),
        require('@tailwindcss/forms'),
    ],
}
