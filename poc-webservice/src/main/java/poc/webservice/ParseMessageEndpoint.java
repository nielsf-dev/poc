package poc.webservice;

import nl.visi.schemas.soap.version_1.ParseMessageConfirmationRequest;
import nl.visi.schemas.soap.version_1.ParseMessageConfirmationResponse;
import nl.visi.schemas.soap.version_1.ParseMessageRequest;
import nl.visi.schemas.soap.version_1.ParseMessageResponse;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class ParseMessageEndpoint {
    //"http://www.visi.nl/schemas/soap/version-1.0"
    private static final String NAMESPACE_URI = "http://www.visi.nl/schemas/soap/version-1.0";

    public ParseMessageEndpoint() {

    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "parseMessageRequest")
    @ResponsePayload
    public ParseMessageResponse parseMessage(@RequestPayload ParseMessageRequest request) {
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
