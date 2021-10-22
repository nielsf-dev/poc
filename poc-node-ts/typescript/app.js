var camelCase = require('camelcase');
var message2 = 'Hello, World!';
console.log(message2);
var message3 = 'foo-bar';
console.log(camelCase(message3));
var mydiv = document.getElementById('changeme');
mydiv.innerText = message3;
