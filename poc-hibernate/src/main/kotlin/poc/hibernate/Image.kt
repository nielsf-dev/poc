package poc.hibernate

import javax.persistence.*
import java.util.Objects

/**
 * Plaatje behorende bij een project.
 */
@Entity
class Image(val url: String) {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO, generator="CUST_SEQ")
    val id: Int = 0

    override fun equals(other: Any?): Boolean {
        if (this === other) return true
        if (javaClass != other?.javaClass) return false

        other as Image

        if (url != other.url) return false

        return true
    }

    override fun hashCode(): Int {
        var result = url.hashCode()
        result = 31 * result + id
        return result
    }


}
