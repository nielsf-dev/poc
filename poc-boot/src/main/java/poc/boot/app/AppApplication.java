package poc.boot.app;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import poc.boot.app.service.SuperService;

import java.io.InputStream;
import java.util.Properties;

@SpringBootApplication
public class AppApplication implements CommandLineRunner {

	@Autowired
	SuperService superService;

	public static void main(String[] args) {
		SpringApplication.run(AppApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		String awesome = superService.doSomethingAwesome();

		InputStream inputStream = AppApplication.class.getClassLoader().getResourceAsStream("application.properties");
		Properties p = new Properties();
		p.load(inputStream);

		String jemoeder = p.getProperty("jemoeder");
		System.out.println(jemoeder);
	}
}
