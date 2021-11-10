kennelijk kan ik doen node app.js en het werkt, waar komt dan die 

const http = require('http');

vandaan?

Built-in modules are distributed with Node.js itself; you don't need to install them from anywhere.
 You load them into your code using require. These built-in modules make up the slim standard library of Node.js -- 
 the minimal core pieces of language functionality that are shipped with Node.js itself and available for use across all projects.
 An example of a built-in module is the http module, which can be used to create an HTTP client or server.
 These modules are developed by the core Node.js team, and are part of the language itself.
 These modules won't change unless they are changed in a new release of Node.js.

Wanneer heb ik dan precies een package.json nodig?
Als ik iets wil exporteren een module?
Of ook voor importeren? 
Of miss als ik met die scripts{} wil werken?

https://heynode.com/tutorial/what-packagejson/
Your project also must include a package.json before any packages can be installed from NPM

** Wat importeer ik precies met require, zowel objecten als functies?
require komt dus echt uit de commonjs wereld, ES gebruikt import en die mag je kennelijk niet zomaar uitvoeren met node.exe   
enfin, je het blijft vaag gedoe, je kan op die module.exports meerdere functies toekennen. Maar kennelijk maar 1 class?
of zo een constructie dus kennelijk:
https://stackoverflow.com/questions/41228221/can-you-export-multiple-classes-from-a-single-nodejs-module

module.exports = {
  Jack : Jack,
  John : John
}

Wat is dat tussen haakjes voor javascript constructie?

Of je doet met array destruction in modules.exports, dan kan het ook kennelijk:
const foo = ['one', 'two', 'three'];
const [red, yellow, green] = foo;


** Wat is die @ die voor modules staat in node_modules?
dat zijn scoped packages kennelijk

** Welke ecmascript versie heb ik nu met mijn npm?
    node is gebaseerd op v8 google javascript engine, die implementeerd wel de laatste stuff..