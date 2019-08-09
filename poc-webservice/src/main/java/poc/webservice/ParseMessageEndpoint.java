package poc.webservice;

import nl.visi.schemas.soap.version_1.ParseMessageConfirmationRequest;
import nl.visi.schemas.soap.version_1.ParseMessageConfirmationResponse;
import nl.visi.schemas.soap.version_1.ParseMessageRequest;
import nl.visi.schemas.soap.version_1.ParseMessageResponse;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;
import org.springframework.ws.soap.SoapHeader;
import org.springframework.ws.soap.SoapHeaderElement;
import org.springframework.ws.soap.SoapMessage;

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
    public ParseMessageResponse parseMessage(@RequestPayload ParseMessageRequest request, SoapMessage soapMessage) {
        SoapHeader soapHeader = soapMessage.getSoapHeader();
        Iterator<SoapHeaderElement> testheader = soapHeader.examineHeaderElements(new QName("http://www.visi.nl/schemas/soap/version-1.0","testheader"));
        SoapHeaderElement next = testheader.next();
        System.out.println(next.getText());

        ParseMessageResponse parseMessageResponse = new ParseMessageResponse();
        parseMessageResponse.setMessage(request.getMessage());
        return parseMessageResponse;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "parseMessageConfirmationRequest")
    @ResponsePayload
    public ParseMessageConfirmationResponse parseMessageConfirmation(@RequestPayload ParseMessageConfirmationRequest request) {
        ParseMessageConfirmationResponse parseMessageResponse = new ParseMessageConfirmationResponse();
        parseMessageResponse.setMessage(request.getMessage().toUpperCase());
        return parseMessageResponse;
    }

}
