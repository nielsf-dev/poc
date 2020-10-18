package org.poc.veryslow

import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PathVariable
import org.springframework.web.bind.annotation.RestController
import java.net.URI
import java.nio.file.Files
import java.nio.file.Path
import java.nio.file.Paths

@RestController
class DummyController {

    @GetMapping("/slow/{seconds}")
    fun slow(@PathVariable seconds: Long):String{
        Thread.sleep(1000 * seconds)
        return "slowed for $seconds"
    }

    @GetMapping("/large")
    fun largeResponse() : ByteArray{
        val s = "C:\\work\\BSVisiBackend4\\packages\\NHibernate.4.1.1.4000\\NHibernate.releasenotes.txt"
        return Files.readAllBytes(Paths.get(s));
    }
}