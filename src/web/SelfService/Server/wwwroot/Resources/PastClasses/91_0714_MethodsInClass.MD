#### Things learned today
* Methods 
    * They are actions and does something
    * Whenever you want to get something from your program you should think of methods (either using one or writing your own)
    * Each method
        * Name
        * Inputs (0 or more)
        * Output (1 output)
        * Does some instructions
    * Methods go in to class (between __{__ and __}__)
    * Syntax
        * Write Method name first
        ```java
            readBook
        ```
        * Add parenthesis

            ```java
                readBook()
            ```
    
        * Add body block
            ```java
                readBook(){

                }
            ```
        * Add return type
            ```java
                void readBook(){
                    
                }
            ```
        * Add instructions
            ```java
                void readBook(){
                    System.out.println("reading books");
                }
            ```
    * They can access class fields
            ```java
                class Student{
                    string name;
                    
                    void readBook(){
                        System.out.println("reading book by :" + name);
                    }
                }
            ```

    Read about more [here](https://github.com/sairamaj/programmingclass/blob/master/sessions/Session7.MD#actionsmethodsfunctionsbehavior)

