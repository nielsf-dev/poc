import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.function.Function;

public class LambdaTest {

    Logger logger = LoggerFactory.getLogger(LambdaTest.class);

    @Test
    public void testMethodReference(){
        String result = add("KING NIELS", String::toLowerCase);
        logger.trace("added " + result);

        String result2 = add("king niels",string -> string.toUpperCase());
        logger.trace("added " + result2);
    }

    @Test
    public void testFunctionClass(){
        // https://www.baeldung.com/java-8-lambda-expressions-tips
        String result = addWithFunctionClass("Doe nou maar normaal", s -> {
            s = s.toLowerCase();
            return s;
        });
        logger.trace("added " + result);
    }

    public interface Foo {
        String method(String string);
    }

    public String addWithFunctionClass(String string, Function<String, String> fn) {
        return fn.apply(string);
    }

    public String add(String string, Foo foo) {
        return foo.method(string);
    }
}
