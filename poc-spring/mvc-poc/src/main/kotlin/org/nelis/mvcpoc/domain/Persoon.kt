package org.nelis.mvcpoc.domain

import javax.persistence.Entity
import javax.persistence.Id
import javax.persistence.Table

@Entity
@Table(name = "personen")
class Persoon {
    @Id
    val id: Int = 0
    var voornaam: String = ""
    var achterNaam: String = ""
    var leeftijd: Int = 0
}