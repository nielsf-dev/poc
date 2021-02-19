package org.nelis.mvcpoc;

import org.nelis.mvcpoc.domain.Persoon;
import org.nelis.mvcpoc.repo.PersoonRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class CommandLiner implements CommandLineRunner {

    private static Logger logger = LoggerFactory.getLogger(CommandLiner.class);

    @Autowired
    PersoonRepository persoonRepository;

    @Override
    public void run(String... args) {
        List<Persoon> all = persoonRepository.findAll();
        logger.info("Aantal personen = " + all.size());
    }
}
