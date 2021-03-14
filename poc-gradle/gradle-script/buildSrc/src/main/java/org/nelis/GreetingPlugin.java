package org.nelis;

import org.gradle.api.Plugin;
import org.gradle.api.Project;
import org.gradle.api.plugins.JavaPluginConvention;
import org.gradle.api.tasks.SourceSetContainer;

public class GreetingPlugin implements Plugin<Project> {
    @Override
    public void apply(Project project) {

        // kan dus zo
        JavaPluginConvention plugin = project.getConvention().getPlugin(JavaPluginConvention.class);
        SourceSetContainer sourceSets = plugin.getSourceSets();

        // MAAR ook zo
        SourceSetContainer sourceSetsendere = (SourceSetContainer) project.getExtensions().getByName("sourceSets");

        project.task("hellofromplugin")
                .doLast(task -> System.out.println("Hello Gradle!"));
    }
}
