package poc.boot.app;

import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;
import org.springframework.context.annotation.Bean;
import org.springframework.orm.jpa.JpaTransactionManager;
import org.springframework.orm.jpa.LocalContainerEntityManagerFactoryBean;
import org.springframework.orm.jpa.vendor.HibernateJpaVendorAdapter;
import org.springframework.transaction.PlatformTransactionManager;
import poc.boot.app.domain.Project;
import poc.boot.app.repositories.ProjectRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import poc.boot.app.service.SuperService;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import java.io.InputStream;
import java.util.Properties;

@SpringBootApplication
public class AppApplication {

	public static void main(String[] args) {
		SpringApplication.run(AppApplication.class, args);
	}

	@Bean
	public DataSource dataSource(){

		HikariConfig cfg = new HikariConfig();

		cfg.setJdbcUrl("jdbc:postgresql://127.0.0.1:5432/mydb");
		cfg.setUsername("postgres");
		cfg.setPassword("toor");

		return new HikariDataSource(cfg);
	}

//	@Bean
//	public LocalContainerEntityManagerFactoryBean entityManagerFactory() {
//
//		HibernateJpaVendorAdapter vendorAdapter = new HibernateJpaVendorAdapter();
//		vendorAdapter.setGenerateDdl(false);
//
//		LocalContainerEntityManagerFactoryBean factory = new LocalContainerEntityManagerFactoryBean();
//		factory.setJpaVendorAdapter(vendorAdapter);
//		factory.setPackagesToScan("poc.boot.app.domain");
//		factory.setDataSource(dataSource());
//		return factory;
//	}
//
//	@Bean
//	public PlatformTransactionManager transactionManager(EntityManagerFactory entityManagerFactory) {
//
//		JpaTransactionManager txManager = new JpaTransactionManager();
//		txManager.setEntityManagerFactory(entityManagerFactory);
//		return txManager;
//	}

	@Bean
	public CommandLineRunner demo(SuperService superService) {

		return (args) -> {
			String awesome = superService.doSomethingAwesome();

			InputStream inputStream = AppApplication.class.getClassLoader().getResourceAsStream("application.properties");
			Properties p = new Properties();
			p.load(inputStream);

			String jemoeder = p.getProperty("jemoeder");
			System.out.println(jemoeder);
			for (String ss : args) {
				System.out.println(ss);
			}
		};
	}
}
