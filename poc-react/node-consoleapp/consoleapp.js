const fs = require('fs');

console.log('yolo');

process.argv.forEach((val, index) => {
  console.log(`${index}: ${val}`);
});
