package poc.webservice;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.ServletRegistrationBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.core.io.ClassPathResource;
import org.springframework.oxm.jaxb.Jaxb2Marshaller;
import org.springframework.ws.config.annotation.EnableWs;
import org.springframework.ws.transport.http.MessageDispatcherServlet;
import org.springframework.ws.wsdl.wsdl11.DefaultWsdl11Definition;
import org.springframework.ws.wsdl.wsdl11.SimpleWsdl11Definition;
import org.springframework.xml.xsd.SimpleXsdSchema;
import org.springframework.xml.xsd.XsdSchema;

@SpringBootApplication
@EnableWs
public class WebserviceApplication {

    @Bean
    public CommandLineRunner commandLineRunner(WebserviceClient webServiceClient) {
        return args -> {
            webServiceClient.callParseMessage();
            System.out.println("werkt");
            System.out.println("werkt");
        };
    }

    @Bean
    public ServletRegistrationBean messageDispatcherServlet(ApplicationContext applicationContext) {
        MessageDispatcherServlet servlet = new MessageDispatcherServlet();
        servlet.setApplicationContext(applicationContext);
        servlet.setTransformWsdlLocations(true);
        return new ServletRegistrationBean(servlet, "/ws/*");
    }

    @Bean(name = "parseMessage")
    public DefaultWsdl11Definition defaultWsdl11Definition(XsdSchema parseMessageSchema) {
        DefaultWsdl11Definition wsdl11Definition = new DefaultWsdl11Definition();
        wsdl11Definition.setPortTypeName("ParseMessagePort");
        wsdl11Definition.setLocationUri("/ws");
        wsdl11Definition.setTargetNamespace("http://www.visi.nl/schemas/soap/version-1.0");
        wsdl11Definition.setSchema(parseMessageSchema);

        return wsdl11Definition;

       // return new SimpleWsdl11Definition(new ClassPathResource("visi.wsdl"));
    }

    @Bean
    public Jaxb2Marshaller marshaller() {
        Jaxb2Marshaller marshaller = new Jaxb2Marshaller();
        // this is the package name specified in the <generatePackage> specified in
        // pom.xml
        marshaller.setPackagesToScan("nl.visi.schemas.soap.version_1");
        return marshaller;
    }

//    @Bean
//    public SOAPConnector soapConnector(Jaxb2Marshaller marshaller) {
//        SOAPConnector client = new SOAPConnector();
//        client.setDefaultUri("http://localhost:8080/service/student-details");
//        client.setMarshaller(marshaller);
//        client.setUnmarshaller(marshaller);
//        return client;
//    }

    @Bean
    public XsdSchema parseMessageSchema() {
        return new SimpleXsdSchema(new ClassPathResource("parseMessage.xsd"));
    }

    public static void main(String[] args) {
        SpringApplication.run(WebserviceApplication.class, args);
    }

}
