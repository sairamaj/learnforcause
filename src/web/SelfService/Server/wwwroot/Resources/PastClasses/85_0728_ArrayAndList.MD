#### Things learned today
* Arrays
    * Arrays are used to hold multiple values in a single variable
    * Syntax
    ```java
        // Declaring names which can hold 3 strings
        String[] names = new String[3];
        names[0] = "sai";       // first one is at 0
        names[1] = "ram";       // second one is at 1
        names[2] = "krishna";   // third one is at 2

        // Printing all the names in array
        for(int i=0; i<names.length; i++){
            System.out.println("name: " + names[i]);
        }

        // Another way of looping is 
        for(String name : names){
            System.out.println(name);
        }

        // Holding integer values
        int[] numbers = new int[3];
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;

        // Looping is same
        for(int i=0; i<numbers.length; i++){
            System.out.println(numbers[i]);
        }

        for(int number: numbers){
            System.out.println(number);
        }
    ```
* ArrayList
    * Arrays cannot expand
    * ArrayList cann expand automatically
    * Syntax
    ```java
        ArrayList names = new ArrayList();
        names.add("sai");
        names.add("ram");
        names.add("krishna");

        // looping
        for(int i=0; i<names.size(); i++){		// size is the method gives number of items
           System.out.println(names.get(i)) ;	// get will get the name at given index
        }

        // we have to use Object here ( we will learn more about this in future class)
        for(Object name: names){
            System.out.println(name);
        }
    ```
* Generic ArrayList
    * The problem with above __ArrayList__ is we want only strings to be in the list, but we can add other than strings also like below
    ```java
        ArrayList names = new ArrayList();
        names.add("sai");
        names.add("ram");
        names.add("krishna");

        names.add(10);  // addding numbers
        names.add(12.2);    // adding decimals
        names.add(true);    // adding booleans
    ```

    * Generic ArrayList will solve the problem where we can put only certain things like below
    ```java
        ArrayList<String> names = new ArrayList<String>();
       
        names.add("sai");
        names.add("ram");
        names.add("krishna");

        // getting all the names
        for(int i=0; i<names.size(); i++) {
        	System.out.println( names.get(i));
        }
        
        // getting all the names
        for(String name : names) {
        	System.out.println(name);
        }
        //names.add(10);  // Error.
        //names.add(12.2);    // Error 
        //names.add(true);    // Error
    ```
    * Syntax: __ArrayList__ followed by __<__ and __DataType__ and then close __>__
    ```java
        ArrayList<String> names = new ArrayList<String>();
        ArrayList<Integer> numbers = new ArrayList<Integer>();
    ```
* Generic ArrayList with objects
    * We can use Generic ArrayList with our custom classes also.
    ```java
        class Person{
            String name;

            // Constructor
            Person(String name){
                this.name = name;
            }
        }
    ```

    ```java
        ArrayList<Person> persons = new ArrayList<Person>();
        Person p1 = new Person("sai");
        persons.add(p1);        // adding person to the list

        Person p2 = new Person("ram");
        persons.add(p2);        // adding person to the list

        // print all persons
        for(int i=0; i<persons.size(); i++){
            Person p = persons.get(i);
            System.out.println(p.name);
        }

        System.out.println("______________________");

        // another way is
        for(Person p: persons){
            System.out.println(p.name);
        }
    ```