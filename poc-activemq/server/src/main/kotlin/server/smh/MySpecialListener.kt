package server.smh

//import org.slf4j.LoggerFactory
//import org.springframework.jms.annotation.JmsListener
//import org.springframework.stereotype.Component
import java.lang.Exception
import javax.jms.Session
import javax.jms.TextMessage

//@Component
open class MySpecialListener{

  //  private val logger = LoggerFactory.getLogger(MySpecialListener::class.java)

  //  @JmsListener(destination="example2")
    fun processMessage(message: TextMessage, session: Session){
      //  logger.info(message.text)

        try {
            // message opslaan in de database met repository injected here
                // als nou de database niet benaderbaar is, fatal loggen/mailen
                // en messages dan maar naar de dead letter queue

            // soap bericht versturen


            // denk niet dat als de dbcall goed gaat maar de soap fout dat de db gerollbacked word
            // of dat de jms session ge-commit word

            // test: je doet 2 findCllas met zo een repository en checkt met de debugger
            // of telkens dezelfde session gebruikt word, gaat goed met de currentSession etc?
        }
        catch(ex: Exception){

            // als hier moet de message in de db ge-update worden met de foutmelding

          //  logger.error("Fout bij verwerken bericht", ex)
            session.rollback()
        }
    }
}