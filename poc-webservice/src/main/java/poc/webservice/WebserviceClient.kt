package poc.webservice

import org.springframework.ws.client.core.support.WebServiceGatewaySupport
import org.springframework.ws.soap.SoapMessage
import poc.webservice.version_1.ObjectFactory
import poc.webservice.version_1.ParseMessage
import poc.webservice.version_1.SOAPServerURL
import poc.webservice.version_1.UniqueID
import javax.xml.bind.JAXBContext

class WebserviceClient : WebServiceGatewaySupport {
    constructor()

    fun callParseMessage(){
        val parseMessage = ParseMessage()
        parseMessage.message = "HET bericht"

        webServiceTemplate.marshalSendAndReceive("http://localhost:5000/soap.asmx", parseMessage) {
            val soapMessage : SoapMessage = it as SoapMessage

            // Unique ID
            val objectFactory = ObjectFactory()
            val uniqueID = UniqueID()
            uniqueID.id = "somethingunique"
            val createUniqueID = objectFactory.createUniqueID(uniqueID)

            val uniqueIdContext = JAXBContext.newInstance(UniqueID::class.java)
            val uniqueIdMarshaller = uniqueIdContext.createMarshaller()
            uniqueIdMarshaller.marshal(createUniqueID, soapMessage.soapHeader.result)

            // SoapServer URL
            val soapServerUrl = SOAPServerURL()
            soapServerUrl.sender = "mysender"
            soapServerUrl.receiver = "myreceiver"
            val createSOAPServerURL = objectFactory.createSOAPServerURL(soapServerUrl)

            val soapServerUrlContext = JAXBContext.newInstance(SOAPServerURL::class.java)
            val soapServerUrlMarshaller = soapServerUrlContext.createMarshaller()
            soapServerUrlMarshaller.marshal(createSOAPServerURL, soapMessage.soapHeader.result)

            // SoapAction
            soapMessage.soapAction = "http://www.visi.nl/schemas/soap/version-1.0/parseMessage"
        }
    }
}