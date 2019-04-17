package org.nelis

import org.gradle.api.DefaultTask
import org.gradle.api.tasks.TaskAction

class NielsTask extends DefaultTask {
    String greeting = 'King Frerichs aan de macht'

    @TaskAction
    def greet() {
        println greeting
    }
}
