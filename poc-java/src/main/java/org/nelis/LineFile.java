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

    protected final Path path;
    protected final List<String> lines;

    public LineFile(Path path) throws IOException {
        this.path = path;
        this.lines = Files.readAllLines(path);
    }

    public void write() throws IOException {
        Files.write(path,lines);
    }

    public void magNiet() throws IOException {
        if(1 == (2-1))
            throw new IOException("balen");
    }

    public void magWel() {
        if(1 == (2-1))
            throw new RuntimeException("balen");
    }
}
