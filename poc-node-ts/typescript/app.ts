const camelCase = require('camelcase');

let message2: string = 'Hello, World!';
console.log(message2);

let message3: string = 'foo-bar';
console.log(camelCase(message3));

const mydiv = document.getElementById('changeme');
mydiv.innerText = message3;