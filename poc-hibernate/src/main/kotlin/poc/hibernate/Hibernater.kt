package poc.hibernate

import org.hibernate.boot.model.naming.ImplicitNamingStrategyJpaCompliantImpl
import org.hibernate.boot.MetadataSources
import org.hibernate.boot.registry.StandardServiceRegistryBuilder
import org.hibernate.boot.registry.BootstrapServiceRegistryBuilder
import javax.persistence.Persistence
import javax.persistence.EntityManagerFactory



class Hibernater{
    fun doBootstrap(){
        val bootstrapRegistryBuilder = BootstrapServiceRegistryBuilder()
        val bootstrapRegistry = bootstrapRegistryBuilder.build()

        val standardRegistry = StandardServiceRegistryBuilder(bootstrapRegistry)
                .configure() // standaard = hibernate.cfg.xml
                .build()

        val metadata = MetadataSources(standardRegistry)
                .addAnnotatedClass(Image::class.java)
                .addAnnotatedClass(Project::class.java)
                .metadataBuilder
                .applyImplicitNamingStrategy(ImplicitNamingStrategyJpaCompliantImpl.INSTANCE)
                .build()

        val sessionFactory = metadata.sessionFactoryBuilder
                .build()

        val session = sessionFactory.openSession()
        val transaction = session.beginTransaction()

        val query = session.createQuery("from Project", Project::class.java)
        val projects = query.resultList
        for (p in projects){
            println(p.titel_nl)
        }

        transaction.commit()
        session.close()
    }

    fun jpaBootstrap(){
        // Create an EMF for our CRM persistence-unit.
        val emf = Persistence.createEntityManagerFactory("MyJpaTest")
        val entityManager = emf.createEntityManager()
        val project = entityManager.find(Project::class.java, 28)
        println(project.titel_nl)

        val query = entityManager.createQuery("from Project", Project::class.java)
        val projects = query.resultList
        for (p in projects){
            println(p.titel_nl)
        }
        entityManager.close()
    }
}