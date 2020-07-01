#### Things learned today
* Eclipse
    * Workspace - Used for separting different sets of projects
        * Give directory name when it launches to set to workspace
* HelloWorld
    * [Create HelloWorld project](https://github.com/sairamaj/programmingclass/blob/master/sessions/Session2.MD#hello-world-java)
* Some terms we learned
    * __Source (aka Code)__
        * Is the file containing instructions for particular language.
            * Ex: Application.java is the Java source file
    * __Java Project__
        * Collection of source file.
    * __Method (aka Function)__
        * Is a set of instructions. We will learn more details about method in upcoming classes.
    * __Run (aka Execute)__
        * Asking the Java to execute your instructions
* Data Type rules
    * You have to declare before you use
        ```java
            // Wrong as you did not declare
            x = 10;
        ```
        ```java
            // Wrong as you declared after
            x = 10;
            int x;
        ```        
        ```java
            // Correct
            int x;
            x = 10;
            int y = 20; // you can declare and assign value at the same time
        ```
    * You cannot redeclare again
        ```java
            int x;
            x = 10;

            int x;      // Wrong 
            char x;     // Wrong
        ```
    * Comments
        * Comments are for your reference and Java does not see them
        ```java
            // This is my notes ( comment)
        ```