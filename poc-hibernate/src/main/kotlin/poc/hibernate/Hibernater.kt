package poc.hibernate

import org.hibernate.boot.model.naming.ImplicitNamingStrategyJpaCompliantImpl
import org.hibernate.boot.MetadataSources
import org.hibernate.boot.registry.StandardServiceRegistryBuilder
import org.hibernate.boot.registry.BootstrapServiceRegistryBuilder

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
}