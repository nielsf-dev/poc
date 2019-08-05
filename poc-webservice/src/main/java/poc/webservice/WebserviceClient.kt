package poc.webservice

import nl.visi.schemas.soap.version_1.ParseMessage
import org.springframework.stereotype.Component
import org.springframework.ws.WebServiceMessageFactory
import org.springframework.ws.client.core.support.WebServiceGatewaySupport

@Component
class WebserviceClient : WebServiceGatewaySupport {
    constructor()

    fun callParseMessage() {
        val parseMessage = ParseMessage()
        parseMessage.message = "HET bericht"

        webServiceTemplate.marshalSendAndReceive("http://localhost:5000/soap.asmx", parseMessage)
    }
}