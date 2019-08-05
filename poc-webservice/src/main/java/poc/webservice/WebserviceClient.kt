package poc.webservice

import nl.visi.schemas.soap.version_1.ParseMessageRequest
import nl.visi.schemas.soap.version_1.ParseMessageResponse
import org.springframework.oxm.jaxb.Jaxb2Marshaller
import org.springframework.stereotype.Component
import org.springframework.util.ClassUtils
import org.springframework.ws.client.core.support.WebServiceGatewaySupport

@Component
class WebserviceClient : WebServiceGatewaySupport {
    constructor()

    fun callParseMessage() {
        val parseMessage = ParseMessageRequest()
        parseMessage.message = "HET bericht"

        val jaxb2Marshaller = Jaxb2Marshaller()
        jaxb2Marshaller.setPackagesToScan(ClassUtils.getPackageName(ParseMessageRequest::class.java))
        jaxb2Marshaller.setPackagesToScan(ClassUtils.getPackageName(ParseMessageResponse::class.java))

        webServiceTemplate.marshaller = jaxb2Marshaller
        webServiceTemplate.unmarshaller = jaxb2Marshaller

        val marshalSendAndReceive = webServiceTemplate.marshalSendAndReceive("http://localhost:8080/ws", parseMessage)
        println(marshalSendAndReceive)
    }
}