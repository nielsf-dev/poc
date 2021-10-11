const circle = require('./circle.js');
var Square = require('./square.js');
var test = require('module');

console.log(`The area of a circle of radius 4 is ${circle.area(4)}`);

const mySquare = new Square(2);
console.log(`The area of mySquare is ${mySquare.area()}`);