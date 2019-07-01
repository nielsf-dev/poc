package poc.boot.app.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.transaction.annotation.Transactional;
import poc.boot.app.domain.Project;
import poc.boot.app.repositories.ProjectRepository;

@Component
public class SuperService {

    @Autowired
    Clock clock;

    @Autowired
    ProjectRepository projectRepository;

    @Transactional
    public String doSomethingAwesome(){
        int theTime = clock.getTheTime();
        String text = "It is " + theTime + " o'clock!";
        System.out.println(text);

        Iterable<Project> projects = projectRepository.findAll();
        for (Project project : projects) {
            System.out.println(project.getTitel_nl());
        }

        return text;
    }
}
