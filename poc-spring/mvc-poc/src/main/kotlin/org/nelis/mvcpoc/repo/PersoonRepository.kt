package org.nelis.mvcpoc.repo

import org.nelis.mvcpoc.domain.Persoon
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.stereotype.Repository

interface PersoonRepository : JpaRepository<Persoon, Int> {
}