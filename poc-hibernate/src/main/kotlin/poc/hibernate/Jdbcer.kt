package poc.hibernate

import java.sql.Connection
import java.sql.DriverManager

class Jdbcer{
    private val url = "jdbc:postgresql://localhost/mydb"
    private val user = "postgres"
    private val password = "toor"

    fun simpleQuery(){
        val connect = connect()
        println("Gelukt: " + connect.clientInfo.size)

        val statement = connect.createStatement()
        val resultSet = statement.executeQuery("select * from project1230")

        while(resultSet.next()){
            val titel = resultSet.getString("titel_nl")
            println(titel)
        }

        resultSet.close()
        statement.close()
        connect.close()
    }

    fun connect(): Connection {
        val conn = DriverManager.getConnection(url, user, password)
        return conn
    }
}