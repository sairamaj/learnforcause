#### Things learned today
* Constructors
    * Whenever we wanted to create a new object , we want to set some of the fields to some known values. This can be achieve by the constructor
    * Example
    ```java
        class Person{
            private String name;
            private int age;

            // Constructor
            Person(String name, int age){
                this.name = name;
                this.age = age;
            }
        }
    ```
    
    * They are like any other methods which can take input
    * The name is same as class name
    * They __cannot__ specify __return__ type
    * They can be called only during constructing the object
    ```java
        // here we calling construcotr with name and age
        Person p  = new Person("sai",20);
    ```
    * __this__ keyword
        * __this__ keyword is used for the class fields and methods
        * It is optional
        * When name conflict occurs (the input parameter name is same as the class field ) then one has to use the __this__ keyword.
        ```java
             class Person{
            private String name;
            private int age;

            Person(String name, int age){
                this.name = name;       // this.name refers to the name in the class
                this.age = age;         // this.age refers to the age in the class.
            }
        }
   ```
* More classes in Tower of Hanoi
    * We have introduced class __Disk__ 
    * Its job is to draw the disk
    ```java
        class Disk{
            private int size;

            Disk(int size){
                this.size = size;
            }
            public void draw(){
                for(int i=0; i<size; i++){
                    System.out.print("-");  // we use print so that the next one will draw on the same line.
                }

                System.out.println("");     // we will move to the next line.
            }
        }
    ```
    * Here we have constructor which takes the size of the disk
    * __draw__ method uses the size 
* Using __Disk__ in __Tower__
    * Tower class draws the 3 disks
    ```java
        public void draw(){
            drawPole();

            // draw the small disk
            Disk small = new Disk(4);
            small.draw();

            // draw the medium disk
            Disk medium = new Disk(8);
            medium.draw();

            // draw the large disk
            Disk large = new Disk(12);
            large.draw();
        }
    ```

     