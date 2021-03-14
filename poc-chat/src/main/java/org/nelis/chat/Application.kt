package org.nelis.chat

import kotlin.jvm.JvmStatic
import org.nelis.chat.Application
import org.slf4j.LoggerFactory
import java.lang.Exception
import java.net.ServerSocket
import java.net.Socket
import java.lang.StringBuffer
import java.nio.CharBuffer
import java.nio.charset.StandardCharsets

object Application {
    private val logger = LoggerFactory.getLogger(Application::class.java)
    @JvmStatic
    fun main(args: Array<String>) {
        try {
            logger.info("Starting server..")
            val port = 18717
            val serverSocket = ServerSocket(port)
            logger.info("Server started: $port")

            logger.info("Listening..")
            val incoming = serverSocket.accept()

            var chr: Int
            val stringBuffer = StringBuffer()
            val inputStream = incoming.getInputStream()
            val reader = inputStream.reader()

            val writer = incoming.getOutputStream().writer()


            val buffer = CharBuffer.allocate(187)
            while(reader.read(buffer) != -1){
                val temp = buffer.toString()
                if(temp.contains("\r")){
                    writer.write(buffer.array())
                    buffer.clear()
                }
            }

//            while (inputStream.read().also { chr = it } != -1) {
//                stringBuffer.append(chr.toChar())
//                if (chr == 13) {
//                    val input = stringBuffer.toString().toUpperCase()
//                    val reply = "CHAT: $input\r\n"
//                    val outputStream = incoming.getOutputStream()
//                    val bytes = reply.toByteArray(StandardCharsets.UTF_8)
//                    for (bt in bytes) {
//                        outputStream.write(bt.toInt())
//                    }
//                    stringBuffer.delete(0, stringBuffer.length - 1)
//                }
//            }
        } catch (ex: Exception) {
            logger.error("Errur", ex)
        }
    }
}