const circle = require('./circle.js');
const mySquare = require('./square.js');
var test = require('module');

console.log(`The area of a circle of radius 4 is ${circle.area(4)}`);

console.log(`The area of mySquare is ${mySquare.area()}`);
console.log(`Something else is ${mySquare.somethingelse(187)}`);