#!/usr/bin/env bash
javac HelloClass.java

jar cfm hello.jar manifest.txt HelloClass.class NewsStation.class
java -jar hello.jar

jar cfe hello2.jar HelloClass HelloClass.class NewsStation.class
java -jar hello2.jar
