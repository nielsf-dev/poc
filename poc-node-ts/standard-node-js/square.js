// Assigning to exports will not modify module, must use module.exports
// moeilijk gedoe, kennelijk als je een class wil toekennen, voldoet die exports shortcut niet en moet je module.exports gebruiken.

class Square {
    constructor(width) {
      this.width = width;
    }
  
    area() {
      return this.width ** 2;
    }
  };

// dit werkt en is dus verwarrend, zo werkt het vet niet in c#, als je een variable gewoon letterlijk een class name geeft, kan je die var als constructor
// gebruiken MKKKAAAAYYYYY
var test = Square;
var p = new test(5);

// heb je een object, mag je er op deze manier gewoon een nieuwe functie aanhangen, A-HA, zo werkt dus de exports
p.somethingelse = (r) => r ** 2 * 23344;
console.log(p.area());
console.log(p.somethingelse(187));

module.exports = p;