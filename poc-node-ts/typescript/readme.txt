om de typescript compiler te installeren:
npm install -g typescript

versie van de compiler:
tsc --v

om gelijk te executen ipv zoals boven eerst compileren:
npm install -g ts-node

kennelijk kon dan niet de console worden aangeroepen, types moesten worden geinstalleerd:
npm install @types/node --save-dev

* als ik dat doe krijg ik kennelijk alleen een package.lock file, daarvan kan ik kennelijk de volgende keer niet installeren dan.
    Waarom alleen package.lock? Wats the deal + wat doet --save-dev 

    --save-dev iig niet verantwoordelijk voor de package.lock, die komt sws bij npm install

    package.lock verantwoordelijk om de tree te locken, hoezo als ik versie 1.13 heb van een library, die andere dingen gebruikt.
    dat staat dan toch in zijn package.json, hoezo kunnen die versies veranderen.

    komt dus door dependencies zoals 
    
    "dependencies": {
        "B": "<0.1.0"
    }

    dan word de ene keer versie 0.1.0 geinstalleerd, maar bij een update versie 0.2.0. package.lock om dit tegen te gaan (WEIRD)