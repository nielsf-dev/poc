import org.junit.Test;

import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class BasicTest {

    @Test
    public void testReadWrite() throws InterruptedException {

        ArrayList<String> strings = new ArrayList();
        strings.add("1");
        strings.add("2");
        strings.add("3");

        ExecutorService executorService = Executors.newFixedThreadPool(3);

        executorService.execute(() -> {
                while(true) {
                    int length = toString().length();
                    for (int i = 0; i < length; i++) {
                        String str = strings.get(i);
                        System.out.println(str);
                    }
                    try {
                        Thread.sleep(500);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
        });

        executorService.execute(() -> {
            while(true) {
                strings.add("somethingnew");
                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });

        Thread.sleep(1000*60);
    }

}
