package threadingbook;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class NoVisibility {
    private static boolean ready;
    private static int number;

    private static class ReaderThread extends Thread {
        public void run() {
            while (!ready)
                Thread.yield();
            System.out.println(number);
        }
    }

    private static ThreadLocal<Connection> connectionHolder
            = new ThreadLocal<>() {
        public Connection initialValue() {
            try {
                return DriverManager.getConnection("blabla");
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
            return null;
        }

        @Override
        public Connection get() {
            return super.get();
        }
    };
    public static Connection getConnection() {
        return connectionHolder.get();
    }

    public static void main(String[] args) {
        new ReaderThread().start();
        number = 432;
        ready = true;
    }
}
