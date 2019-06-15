package poc.hibernate

import javax.persistence.Persistence

class Hibernater{
    fun doEntityManager(){
        val entityManagerFactory = Persistence.createEntityManagerFactory("puta madre")
    }
}