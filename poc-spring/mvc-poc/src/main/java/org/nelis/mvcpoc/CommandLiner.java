package org.nelis.mvcpoc;

import org.nelis.mvcpoc.domain.Persoon;
import org.nelis.mvcpoc.repo.PersoonRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.io.InputStream;
import java.net.Socket;
import java.util.List;

@Component
public class CommandLiner implements CommandLineRunner {

    private static Logger logger = LoggerFactory.getLogger(CommandLiner.class);

    @Autowired
    PersoonRepository persoonRepository;

    @Override
    public void run(String... args) {
        makeSocketConnection();
        getAll();
    }

    public void makeSocketConnection(){
        try {
            Socket socket = new Socket("localhost",5188);
            InputStream inputStream = socket.getInputStream();

            byte[] bytes = inputStream.readAllBytes();
            logger.info(bytes.toString());

        } catch (IOException e) {
            logger.error(e.toString());
        }
    }

    public void testing(){
        logger.info("hier wel goed");
    }

    private void getAll() {
        List<Persoon> all = persoonRepository.findAll();
        logger.info("Aantal personen = " + all.size());
    }
}
