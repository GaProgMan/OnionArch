const CSS = [
  'bootstrap/dist/css'
];
const JS = [
  'bootstrap/dist/js',
  'jquery/dist',
  'jquery-validation/dist/additional-methods.js',
  'jquery-validation/dist/jquery.validate.js',
  'jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
];
const Fonts = [
  'bootstrap/dist/fonts'
]

module.exports = [...JS, ...CSS, ...Fonts];
