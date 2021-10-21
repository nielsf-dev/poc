const { PI } = Math;

// exports is the same as module.exports = commonjs
exports.area = (r) => PI * r ** 2 * 234;
module.exports.circumference = (r) => 2 * PI * r;