package client

import org.apache.activemq.ActiveMQConnectionFactory
import org.slf4j.Logger
import org.slf4j.LoggerFactory
import org.springframework.boot.CommandLineRunner
import org.springframework.boot.SpringApplication
import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.context.annotation.Bean
import org.springframework.jms.core.JmsTemplate
import org.springframework.jms.core.MessageCreator
import org.springframework.jms.support.destination.DynamicDestinationResolver
import javax.jms.DeliveryMode
import javax.jms.Destination
import javax.jms.Message
import javax.jms.Session


@SpringBootApplication
open class App {

    private val logger: Logger = LoggerFactory.getLogger(App::class.java)

    @Bean
    open fun commandLineRunner(template: JmsTemplate) : CommandLineRunner{
        return CommandLineRunner {
            logger.info("we here")

            template.defaultDestinationName  = "example2"
            for(i in 1..50) {
                val t = Thread{
                    template.send { session -> session.createTextMessage("Hans Kazan is heel wat van plan.") }
                }
                t.start()

                // doOldSchoolSend()
            }

            //run()
            logger.info("done")
        }
    }
}

fun main(args: Array<String>) {
    //SpringApplication.run(App::class.java, *args).close()
    doOldSchoolBrowse()
}

fun run() {
    try {
        // Create a ConnectionFactory
        val connectionFactory = ActiveMQConnectionFactory("tcp://192.168.63.81:61616")

        // Create a Connection
        val connection = connectionFactory.createConnection("root","toor")
        connection.start()

        // Create a Session
        val session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE)

        // Create the destination (Topic or Queue)
        val destination = session.createQueue("example2")

        // Create a MessageProducer from the Session to the Topic or Queue
        val producer = session.createProducer(destination)
        producer.deliveryMode = DeliveryMode.NON_PERSISTENT

        // Create a messages
        val text = "Hello world! From: " + Thread.currentThread().name + " : "
        val message = session.createTextMessage(text)

        // Tell the producer to send the message
        System.out.println("Sent message: " + message.hashCode() + " : " + Thread.currentThread().name)
        producer.send(message)

        // Clean up
        session.close()
        connection.close()
    } catch (e: Exception) {
        println("Caught: $e")
        e.printStackTrace()
    }

}

private fun doOldSchoolBrowse() {
    val connectionFactory = ActiveMQConnectionFactory("tcp://192.168.63.81:61616")
    val connection = connectionFactory.createConnection("root", "toor")

    connection.use {
        connection.start()
        val session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE)

        session.use {
            val dlq = session.createQueue("DLQ")
            val browser = session.createBrowser(dlq)
            browser.use {
                for (any in browser.enumeration) {
                    val message = any as Message
                    println(message.jmsMessageID)
                }
            }
        }
    }
}

private fun doOldSchoolSend() {
    val connectionFactory = ActiveMQConnectionFactory("tcp://192.168.63.81:61616")
    val connection = connectionFactory.createConnection("root", "toor")

    connection.use {
        connection.start()
        val session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE)

        session.use {
            val destination = session.createQueue("example2")
            val producer = session.createProducer(destination)
            producer.deliveryMode = DeliveryMode.NON_PERSISTENT

            producer.use {
                val message = session.createTextMessage()
                message.text = "JE-moeDEr"
                producer.send(message)
            }
        }
    }
}
