package org.nelis.async.future;

import org.junit.jupiter.api.Test;

import java.util.concurrent.ExecutionException;

class AsyncBasicsTest {
    @Test
    void test() {
        try {
            AsyncBasics asyncBasics = new AsyncBasics();
            asyncBasics.basicFuture();
            asyncBasics.basicCompletableFuture();

        } catch (InterruptedException e) {
            e.printStackTrace();
        } catch (ExecutionException e) {
            e.printStackTrace();
        }
    }
}