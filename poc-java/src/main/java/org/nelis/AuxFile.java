package org.nelis;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.nio.file.Path;
import java.util.Spliterator;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Stream;

public class AuxFile extends LineFile {

    private static final Logger logger = LoggerFactory.getLogger(AuxFile.class);

    private final Pattern classNamePattern;

    public AuxFile(Path path) throws IOException {
        super(path);
        classNamePattern = Pattern.compile("public\\sclass\\s([^\\s]*)\\s:");
    }

    public void insertNameProperty() throws IOException {
        Stream<String> stream = lines.stream();

        stream.forEach(l -> {
            String line = l.trim();
            Matcher matcher = classNamePattern.matcher(line);
            if(matcher.find()){
                String className = matcher.group(1);
                logger.info("Inserting {}", className);

                int insertIndex = lines.indexOf(l)+2;
                String property = String.format("\t\tpublic string Name => \"BsVisi.Service.Raamwerken.AuxSystem.%s\";",className);
                lines.add(insertIndex, property);
                lines.add(insertIndex+1, " ");

                return;
            }
        });

//        for(int i=0; i<lines.size(); i++){
//            String line = lines.get(i).trim();
//            Matcher matcher = classNamePattern.matcher(line);
//            if(matcher.find()){
//                String className = matcher.group(1);
//                logger.info("Inserting {}", className);
//
//                int insertIndex = i+2;
//                String property = String.format("\t\tpublic string Name => \"BsVisi.Service.Raamwerken.AuxSystem.%s\";",className);
//                lines.add(insertIndex, property);
//                lines.add(insertIndex+1, " ");
//
//                this.write();
//                return;
//            }
//        }
//
//        logger.info("Geen insertName match voor {}", path.toString());
    }
}
