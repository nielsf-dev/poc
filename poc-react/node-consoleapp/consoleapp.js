const fs = require('fs');

console.log('yolo');
console.error()

process.argv.forEach((val, index) => {
  console.log(`${index}: ${val}`);
});
