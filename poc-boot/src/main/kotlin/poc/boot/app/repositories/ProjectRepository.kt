package poc.boot.app.repositories

import poc.boot.app.domain.Project
import org.springframework.data.repository.PagingAndSortingRepository

interface ProjectRepository : PagingAndSortingRepository<Project, Int>
