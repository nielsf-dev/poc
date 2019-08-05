package poc.webservice;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.ServletRegistrationBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.core.io.ClassPathResource;
import org.springframework.ws.config.annotation.EnableWs;
import org.springframework.ws.transport.http.MessageDispatcherServlet;
import org.springframework.ws.wsdl.wsdl11.DefaultWsdl11Definition;
import org.springframework.xml.xsd.SimpleXsdSchema;
import org.springframework.xml.xsd.XsdSchema;

@SpringBootApplication
@EnableWs
public class WebserviceApplication {

    @Bean
    public CommandLineRunner commandLineRunner(WebserviceClient webServiceClient) {
        return args -> {
          //  webServiceClient.callParseMessage();
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

    @Bean(name = "countries")
    public DefaultWsdl11Definition defaultWsdl11Definition(XsdSchema parseMessage) {
        DefaultWsdl11Definition wsdl11Definition = new DefaultWsdl11Definition();
        wsdl11Definition.setPortTypeName("ParseMessagePort");
        wsdl11Definition.setLocationUri("/ws");
        wsdl11Definition.setTargetNamespace("http://www.visi.nl/schemas/soap/version-1.0");
        wsdl11Definition.setSchema(parseMessage);

        return wsdl11Definition;
    }

    @Bean
    public XsdSchema parseMessage() {
        return new SimpleXsdSchema(new ClassPathResource("parseMessage.xsd"));
    }

    public static void main(String[] args) {
        SpringApplication.run(WebserviceApplication.class, args);
    }

}
