package org.nelis;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LineFile {

    private static final Logger logger = LoggerFactory.getLogger(LineFile.class);

    private final Path path;
    private final Pattern classNamePattern;
    private final List<String> lines;

    public LineFile(Path path) throws IOException {
        this.path = path;
        this.lines = Files.readAllLines(path);
        classNamePattern = Pattern.compile("public\\sclass\\s([^\\s]*)\\s:");
    }

    public void write() throws IOException {
        Files.write(path,lines);
    }

    public void insertName() {

        for(int i=0; i<lines.size(); i++){
            String line = lines.get(i).trim();
            Matcher matcher = classNamePattern.matcher(line);
            if(matcher.find()){
                String className = matcher.group(1);
                logger.info(className);
            }
        }
    }
}
