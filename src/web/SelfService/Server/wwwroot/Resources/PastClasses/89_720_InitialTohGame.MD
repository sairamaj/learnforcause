#### Things learned today
* We started Tower of Honai game 
* Created __Tower__ class
    * Step-1
        * Added bare minimum
        ```java
            String name;
            void draw(){
                System.out.println("drawing tower");
            }
        ```
        * Created __Tower__ object in __main__ method
        ```java
            Tower towerA;
            towerA = new Tower();
            towerA.name = "Tower-A";
            towerA.draw();
        ```
    * Step-2
        * Added 3 more methods in __Tower__ to draw the __pole__, __base__ and __title__
        ```java
        
            void draw(){
                drawPole();
                drawBase();
                drawTitle();
            }

            void drawPole(){
                for(int i=0; i<4; i++){
                    System.out.println("     |");
                }
            }
        
            void drawBase(){
                System.out.println("    ------------------");
            }
        
            void drawTitle(){
                System.out.println("    " + name);
            }
        ```
* Naming Conventions
    * We need to follow standard naming convensions
    * Class names are singular nounds and start with Captial letter
        * example
            * Application
            * Tower
    * Method names start with lower case and follow [camelCase](https://techterms.com/definition/camelcase)
        * example
            * main
            * drawPole
            * drawBase
    * Variables start with lower case and follow [camelCase](https://techterms.com/definition/camelcase)
        * example
            * towerA
            * name


