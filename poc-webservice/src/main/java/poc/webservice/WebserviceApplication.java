package poc.webservice;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.oxm.jaxb.Jaxb2Marshaller;

@SpringBootApplication
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
    public Jaxb2Marshaller marshaller() {
        Jaxb2Marshaller marshaller = new Jaxb2Marshaller();
        // this package must match the package in the <generatePackage> specified in
        // pom.xml
        marshaller.setPackagesToScan("poc.webservice.version_1");
       // marshaller.setContextPath("visi.wsdl");
        return marshaller;
    }

    @Bean
    public WebserviceClient countryClient(Jaxb2Marshaller marshaller) {
        WebserviceClient client = new WebserviceClient();
        client.setDefaultUri("http://localhost:5000/soap.asmx");
        client.setMarshaller(marshaller);
        client.setUnmarshaller(marshaller);
        return client;
    }

    public static void main(String[] args) {
        SpringApplication.run(WebserviceApplication.class, args);
    }

}
