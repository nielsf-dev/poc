//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.8-b130911.1802 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2019.08.10 at 12:39:30 AM CEST 
//


package nl.visi.schemas.soap.version_1;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the nl.visi.schemas.soap.version_1 package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _UniqueID_QNAME = new QName("http://www.visi.nl/schemas/soap/version-1.0", "UniqueID");
    private final static QName _SOAPCentralServerURL_QNAME = new QName("http://www.visi.nl/schemas/soap/version-1.0", "SOAPCentralServerURL");
    private final static QName _Attachments_QNAME = new QName("http://www.visi.nl/schemas/soap/version-1.0", "Attachments");
    private final static QName _SOAPServerURL_QNAME = new QName("http://www.visi.nl/schemas/soap/version-1.0", "SOAPServerURL");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: nl.visi.schemas.soap.version_1
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link SOAPCentralServerURL }
     * 
     */
    public SOAPCentralServerURL createSOAPCentralServerURL() {
        return new SOAPCentralServerURL();
    }

    /**
     * Create an instance of {@link UniqueID }
     * 
     */
    public UniqueID createUniqueID() {
        return new UniqueID();
    }

    /**
     * Create an instance of {@link GetMaxRequestLengthResponse }
     * 
     */
    public GetMaxRequestLengthResponse createGetMaxRequestLengthResponse() {
        return new GetMaxRequestLengthResponse();
    }

    /**
     * Create an instance of {@link UploadChunk }
     * 
     */
    public UploadChunk createUploadChunk() {
        return new UploadChunk();
    }

    /**
     * Create an instance of {@link ParseMessageResponse }
     * 
     */
    public ParseMessageResponse createParseMessageResponse() {
        return new ParseMessageResponse();
    }

    /**
     * Create an instance of {@link GetMaxRequestLength }
     * 
     */
    public GetMaxRequestLength createGetMaxRequestLength() {
        return new GetMaxRequestLength();
    }

    /**
     * Create an instance of {@link Attachments }
     * 
     */
    public Attachments createAttachments() {
        return new Attachments();
    }

    /**
     * Create an instance of {@link ParseMessageConfirmationResponse }
     * 
     */
    public ParseMessageConfirmationResponse createParseMessageConfirmationResponse() {
        return new ParseMessageConfirmationResponse();
    }

    /**
     * Create an instance of {@link CheckFileHashResponse }
     * 
     */
    public CheckFileHashResponse createCheckFileHashResponse() {
        return new CheckFileHashResponse();
    }

    /**
     * Create an instance of {@link ParseMessage }
     * 
     */
    public ParseMessage createParseMessage() {
        return new ParseMessage();
    }

    /**
     * Create an instance of {@link UploadChunkResponse }
     * 
     */
    public UploadChunkResponse createUploadChunkResponse() {
        return new UploadChunkResponse();
    }

    /**
     * Create an instance of {@link ParseMessageConfirmation }
     * 
     */
    public ParseMessageConfirmation createParseMessageConfirmation() {
        return new ParseMessageConfirmation();
    }

    /**
     * Create an instance of {@link CheckFileHash }
     * 
     */
    public CheckFileHash createCheckFileHash() {
        return new CheckFileHash();
    }

    /**
     * Create an instance of {@link SOAPServerURL }
     * 
     */
    public SOAPServerURL createSOAPServerURL() {
        return new SOAPServerURL();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link UniqueID }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.visi.nl/schemas/soap/version-1.0", name = "UniqueID")
    public JAXBElement<UniqueID> createUniqueID(UniqueID value) {
        return new JAXBElement<UniqueID>(_UniqueID_QNAME, UniqueID.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link SOAPCentralServerURL }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.visi.nl/schemas/soap/version-1.0", name = "SOAPCentralServerURL")
    public JAXBElement<SOAPCentralServerURL> createSOAPCentralServerURL(SOAPCentralServerURL value) {
        return new JAXBElement<SOAPCentralServerURL>(_SOAPCentralServerURL_QNAME, SOAPCentralServerURL.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Attachments }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.visi.nl/schemas/soap/version-1.0", name = "Attachments")
    public JAXBElement<Attachments> createAttachments(Attachments value) {
        return new JAXBElement<Attachments>(_Attachments_QNAME, Attachments.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link SOAPServerURL }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.visi.nl/schemas/soap/version-1.0", name = "SOAPServerURL")
    public JAXBElement<SOAPServerURL> createSOAPServerURL(SOAPServerURL value) {
        return new JAXBElement<SOAPServerURL>(_SOAPServerURL_QNAME, SOAPServerURL.class, null, value);
    }

}
