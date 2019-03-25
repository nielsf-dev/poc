#!/usr/bin/env bash
javac HelloClass.java
mv NewsStation.class /home/niels/src

java -cp ".:/home/niels/src" HelloClass
