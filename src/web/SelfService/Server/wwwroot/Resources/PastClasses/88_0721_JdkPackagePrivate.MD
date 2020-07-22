#### Things learned today

* __private__ key word
    * private key word for method will make the method to hide from outside the class.
    ```java
        class Tower{
            private void drawPole(){
            }
        }

        class Application{
            public static void main(){
                Tower towerA;
                towerA.drawPole();  // Erro drawPole is private
            }
        }
    ```
* Encaptulation
    * The encapulation is one of the object oriented principle
        * part-1
            * __Grouping__ of __methods__ and __data__(fields) in to one unit __class__
        * part-2
            * __hide__ the details  (in Java using __private__ keyword)
    * read more about [here](https://stackify.com/oop-concept-for-beginners-what-is-encapsulation/)
* JDK
    * __J__ ava __D__ eveloper __K__ it
        * A set of classes ready to be used in Java projects
        * Instead of doing it our own , we can look around and see if any method exists to be used readily we can use it.
* Package
    * A group of related classes ![packages](../../images/packages.PNG)
    * Class with same can exists in different packages (but you cannot have same class name in one packages)
    * Some of the standard packages are
        * java.lang
        * java.util
    * The full name of class includes package
        * for example the full name of  class __Date__ in __JDK__ is __java.util.Date__
    * 2 ways of referencing in class
        * using fullname
            ```java
                java.util.Date date;
            ```
        * using __import__ keyword in the top of the file
            ```java
                import java.util.*;

                public class Application{
                    static void main(){
                        Date date;      // import keyword at the top means we don't have to use full name
                        java.util.Date date2;   // still you can use full name.
                    }
                }
            ```
    * Creating your own package
        * when creating class one can input the package name

        ![custompackage](../../images/custompackage.PNG)

        ![custompackage](../../images/packageinsexplorer.PNG)

        
* Methods,Classes,Packages
    * Whenever you need to get something done from Java programming you need to look for below
        * Method
            * you can find from documentation or googling for it
        * Inputs and Outputs
            * Find out what inputs it needs to get job done and what does it give back
        * In Which class exists (methods exists inside the classes)
        * In which package it exists
    * My aim is to print todays date
        * By googing I found 
            * method toString
            * in Date Class
            * in java.util
        ```java
            java.util.Date date;
            date = new java.util.Date();
            System.out.println("today date is" + date.toString());
        ```