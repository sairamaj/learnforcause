#### Things learned today
* __addSpecial implementation__
    * We are going to write below class to do the add special (please refer to the previous java class about the details of add special )
    ```java
            class Math{
                // This method takes one number
                // Calculates  previous sum + given number
                // Memorizies the sum calculated
                // Return sum
                // Right now this is dummy where we are going to put actual logic
                int addSpecial(int number){
                    return 0;
                }
            }
    ```
    * We will test with this 3 objects like below
    ```java
            Math mathA = new Math(1);
            Math mathB = new Math(2);
            Math mathC = new Math(3);
            
            int value = mathA.addSpecial(4);
            System.out.println("From mathA :" + value);	// supposed to come as 5 (1+4)
            
            value = mathB.addSpecial(4);
            System.out.println("From mathB :" + value);	// supposed to come as 6(2+4)

            value = mathA.addSpecial(7);
            System.out.println("From mathA :" + value);	// supposed to come as 12 (5+7)

            value = mathB.addSpecial(7);
            System.out.println("From mathB :" + value);	// supposed to come as 13 (6+7)
            
            value = mathC.addSpecial(7);
            System.out.println("From mathC :" + value);	// supposed to come as 10 (3+7)

            value = mathC.addSpecial(8);
            System.out.println("From mathC :" + value);	// supposed to come as 18(10+8)
            
            int val = Math.add(2, 3);
            System.out.println(val);
            
            val = Math.add(4, 6);
            System.out.println(val);
    ```
    * Implementing __addSpecial__ method
    ```java
    
            public class Math {
                
                int brainValue;	// instance variable
                
                Math(int beginValue) {
                    this.brainValue = beginValue;
                }


                int addSpecial(int number) {	// instance method
                    // get what was stored from my brain (1) and call my brainvalue
                    // add number + brainvalue => newNumber (4)
                    // update my brainvalue value with newNumber(5)
                    // return newNewNumer (5)
                    
                    int prevStoredValue = this.brainValue;
                    int sum = prevStoredValue + number;	// local vari
                    this.brainValue = sum;
                    return sum;
                }
            }
    ```
    * __Math__ constructor takes the initial value given and assign to the __brainValue__
    * In above the __instance variables__ (__brainValue__ ) remembers the previous sum given
    * Before returning the sum, the sum is stored in __brianValue__
    * The instance variable like this will be part of the each object and has its own copy.
    * Thats how mathA, mathB and mathC will have their own previous sum in the __brainValue__ (instance variable)


* __static__ __add__ method
    * For the above class lets add a method where it takes 2 parameters and returns the sum of those 2 parameters
    ```java
            class Math{
                static int add(int x, int y) {
                    int sum = x+y;
                    
                    return sum;
                }                
            }
    ```
    * Here add takes 2 parameters and give the sum of these 2 numbers
    * It does not need to remember anything ( in otherwords it does not use any instance variables)
    * This method can be declared as __static__
    * Calling this method is on __class__ like below
    ```java
            int result = Math.add(2,4);
    ```

* __Do loop__
    * we have seen __for__ loop earlier
    * Lets see another loop which is __do__
    ```java
            do{
                // some instructions
            }while(// some condition where the loop will be continuing till it is true)
    ```
    * Lets print 10 numbers using this 
    ```java
        int i=0;
        do{
            System.out.println("i: " + i);
            i++;
        }while(i<10);
    ```
* __Input from user__
    * In order to get some input from user we will be using __JDK__ class __Scanner__
    ```java
        import java.util.*; // Scanner exists in java.util package
    ```
    ```java
        Scanner scanner = new Scanner(System.in);
        System.out.print("Please enter value");
        String input = scanner.next();
        System.out.println("User input is:" + input);
    ```
* __Asking the command in our Toh game__
    * Lets add the user input command in Toh game
    ```java
            // After drawing the towers we will be adding below lines.
            boolean quit=false;
            
            do {
                System.out.println("Please enter command(quit or move):");
                
                Scanner scanner = new Scanner(System.in);
                String command = scanner.next();
                
                if(command.equals("move")) {
                    System.out.println("ok you want to move...");
                }else if(command.equals("quit")) {
                    quit = true;
                }else {
                    System.out.println("wrong command(please enter move/quit");
                }
                
            }while(quit==false);

    ```
    * In above we will use __do__ loop and we will quit once the user enters quit command
    * __while(quit==false)__ will be condition when quit=true this condition will be false (true==false is false) and will quit
    * At present when user enters move we will just print moving and actual moving of disk we will implement in next class.