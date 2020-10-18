package poc.webservice

import nl.visi.schemas.soap.version_1.*
import org.springframework.beans.factory.annotation.Autowired
import org.springframework.oxm.jaxb.Jaxb2Marshaller
import org.springframework.stereotype.Component
import org.springframework.ws.WebServiceMessage
import org.springframework.ws.client.core.WebServiceMessageCallback
import org.springframework.ws.client.core.support.WebServiceGatewaySupport
import org.springframework.ws.soap.SoapMessage
import javax.xml.bind.JAXBContext

@Component
class WebserviceClient @Autowired constructor(marshaller: Jaxb2Marshaller) : WebServiceGatewaySupport() {

    init{
        webServiceTemplate.marshaller = marshaller
        webServiceTemplate.unmarshaller = marshaller
    }

    fun callParseMessage() {
        val parseMessage = ParseMessageRequest()
        parseMessage.message = "HET bericht"

//        val jaxb2Marshaller = Jaxb2Marshaller()
//        jaxb2Marshaller.setPackagesToScan(ClassUtils.getPackageName(ParseMessageRequest::class.java))
//        jaxb2Marshaller.setPackagesToScan(ClassUtils.getPackageName(ParseMessageResponse::class.java))
//
//        webServiceTemplate.marshaller = jaxb2Marshaller
//        webServiceTemplate.unmarshaller = jaxb2Marshaller

        val marshalSendAndReceive = webServiceTemplate.marshalSendAndReceive("http://localhost:8080/ws", parseMessage, myRequestCallBack()) as ParseMessageResponse
        println(marshalSendAndReceive.parseMessageResult)

        val conf = ParseMessageConfirmationRequest()
        conf.message = "hele kleine lettertjes"
        val receive = webServiceTemplate.marshalSendAndReceive("http://localhost:8080/ws", conf) as ParseMessageConfirmationResponse
        println(receive.parseMessageConfirmationResult)
    }
}

class myRequestCallBack : WebServiceMessageCallback {
    override fun doWithMessage(message: WebServiceMessage?) {
        val soapMessage = message as SoapMessage
        val soapHeader = soapMessage.soapHeader

        val context = JAXBContext.newInstance(UniqueID::class.java,SOAPCentralServerURL::class.java)
        val marshaller = context.createMarshaller()

        //val headerElement = soapMessage.soapHeader.addHeaderElement(QName("http://www.visi.nl/schemas/soap/version-1.0","testheader"))
        val objectFactory = ObjectFactory()
        val uniqueID = UniqueID()
        uniqueID.id = "superuniek"
        val uniqueIDWrapper = objectFactory.createUniqueID(uniqueID)
        marshaller.marshal(uniqueIDWrapper, soapHeader.result)

        val soapServerURL = SOAPCentralServerURL()
        soapServerURL.server = "superserver"
        val serverWrapper = objectFactory.createSOAPCentralServerURL(soapServerURL)
        marshaller.marshal(serverWrapper, soapHeader.result)

        //println(headerElement.text)
    }

}
