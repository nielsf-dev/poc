package poc.webservice;

import nl.visi.schemas.soap.version_1.*;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;
import org.springframework.ws.soap.SoapHeader;
import org.springframework.ws.soap.SoapHeaderElement;
import org.springframework.ws.soap.SoapMessage;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.namespace.QName;
import java.util.Iterator;

@Endpoint
public class ParseMessageEndpoint {
    //"http://www.visi.nl/schemas/soap/version-1.0"
    private static final String NAMESPACE_URI = "http://www.visi.nl/schemas/soap/version-1.0";

    public ParseMessageEndpoint() {

    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "parseMessageRequest")
    @ResponsePayload
    public ParseMessageResponse parseMessage(@RequestPayload ParseMessageRequest request,
                                             @org.springframework.ws.soap.server.endpoint.annotation.SoapHeader("{http://www.visi.nl/schemas/soap/version-1.0}UniqueID") SoapHeaderElement uniqueIDElement,
                                             SoapMessage soapMessage) throws JAXBException {

        JAXBContext context = JAXBContext.newInstance(ObjectFactory.class);
        Unmarshaller unmarshaller = context.createUnmarshaller();

        // unmarshal the header from the specified source
        JAXBElement<UniqueID> headers = (JAXBElement<UniqueID>) unmarshaller.unmarshal(uniqueIDElement.getSource());
        System.out.println(headers.getValue().getID());

        SoapHeader soapHeader = soapMessage.getSoapHeader();
        Iterator<SoapHeaderElement> testheader = soapHeader.examineHeaderElements(new QName("http://www.visi.nl/schemas/soap/version-1.0","testheader"));
        SoapHeaderElement next = testheader.next();
        System.out.println(next.getText());

        ParseMessageResponse parseMessageResponse = new ParseMessageResponse();
        parseMessageResponse.setParseMessageResult(request.getMessage());
        return parseMessageResponse;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "parseMessageConfirmationRequest")
    @ResponsePayload
    public ParseMessageConfirmationResponse parseMessageConfirmation(@RequestPayload ParseMessageConfirmationRequest request) {
        ParseMessageConfirmationResponse parseMessageResponse = new ParseMessageConfirmationResponse();
        parseMessageResponse.setParseMessageConfirmationResult(request.getMessage().toUpperCase());
        return parseMessageResponse;
    }

}
