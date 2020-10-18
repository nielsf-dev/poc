package org.poc.veryslow

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class VeryslowApplication

fun main(args: Array<String>) {
    runApplication<VeryslowApplication>(*args)
}
