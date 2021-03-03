import org.junit.jupiter.api.Test;
import org.nelis.LineFile;

import java.io.IOException;
import java.nio.file.Paths;

class LineFileTest {

    @Test
    void test() throws IOException {
        String filePath = "C:\\work\\visi-backend\\core\\Service\\Raamwerken\\AuxSystem\\Functions\\OnMessageSave\\MailSubject.cs";
        LineFile lineFile = new LineFile(Paths.get(filePath));
    }
}