package server.smh

import org.slf4j.LoggerFactory
import org.springframework.jms.annotation.JmsListener
import org.springframework.stereotype.Component

@Component
open class MySpecialListener{

    private val logger = LoggerFactory.getLogger(MySpecialListener::class.java)

    @JmsListener(destination="example2")
    fun processMessage(message: org.apache.activemq.command.ActiveMQMessage){
        logger.info(message.toString())

        val content = String(message.content.data,Charsets.UTF_8)
        logger.info(content)
    }
}