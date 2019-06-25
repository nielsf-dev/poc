package poc.boot.app.repositories

import poc.boot.app.domain.Image
import org.springframework.data.repository.CrudRepository

interface ImageRepository : CrudRepository<Image, Int>
