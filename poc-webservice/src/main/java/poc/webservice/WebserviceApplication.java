package poc.webservice;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class WebserviceApplication {

    @Bean
    public CommandLineRunner commandLineRunner() {
        return args -> {
            System.out.println("werkt");
            System.out.println("werkt");
        };
    }

    public static void main(String[] args) {
        SpringApplication.run(WebserviceApplication.class, args);
    }

}
