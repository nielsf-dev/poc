/*
 * This Kotlin source file was generated by the Gradle 'init' task.
 */
package poc.logback

import org.slf4j.LoggerFactory

/**
 * Een app.
 *
 * Dit doet dus niet veel.
 *
 * @author Niels Frerichs
 */
class App {
    val logger = LoggerFactory.getLogger(App::class.java)
    val greeting: String
        get() {
            logger.info("In the greeting property")
            return "Hello world."
        }
}

fun main(args: Array<String>) {
    println(App().greeting)
}