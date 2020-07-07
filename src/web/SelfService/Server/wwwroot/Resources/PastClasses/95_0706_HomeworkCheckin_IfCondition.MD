#### Things learned today
* Homework Checkin
    * Option-1
        * Make your eclipse workspace to match with your git working directory
        * If you add any projects through eclipse then you can use the following commands to get in to git cloud repository
        ```cmd
            git status
            git add *
            git commit -m "your comment here"
            git push
        ```
    * Option-2
        * Through File Explorer you can copy your project from eclipse workspace to git repository directory
* Java Syntax
    * You need to be familiar with syntax
    * As we keep learning we will introduce new syntax
    * As of now we have following syntax
        * semi colon at the end of line
        ```java
            System.out.println("Hello World");
        ```
        * match opening flower (__{__) bracket to closeing (__}__)
        ```java
        public class Application {  // bracket-1-opening
            public static void main(String[] args){     // bracket-2-openging

            }   // bracket-2-openging
        }  // bracket-1-opening
        ```
        [view picture here](https://github.com/sairamaj/programmingclass/blob/master/sessions/Session4.MD#matching-curly-brackets----)
        
        * For method bracket is called parenthesis with openging as __(__ and closing as __)__
        ```java
            System.out.println("Hello world")  // see ( and   )
        ```
* Indentation
    * Indentation is alignment of the code.
    * You can use  __Ctrl+Shift+F__ in the eclipse to align the code automatically.

* If condition
    * Get comfortable with syntax which is described in steps below
    * Step-1
        * Decide how many conditions you have
        * Write initial block (you will see errors here which is ok)
        ```java
            if(   ){

            }else if(   ){

            }else if(   ){

            }else{

            }
        ```
        * Above weh ave 4 conditions (one __if__ , two __else if__ and one __else__)
    * Step-2
        * Fix errors with dummy conditions (with __true__ and __false__)
        ```java
            if( true  ){

            }else if( false  ){

            }else if( false  ){

            }else{

            }
        ```
    * Step-3
        * Fill the logic between the conditions
        * Below example we are using __age__ and __driver permit__ conditions
        ```java
            int age = 10;
            if( age <15> ){
                System.out.println("Cannot get driver permit")
            }else if( age >=15 && age <=18  ){
                System.out.println("You need parent permission.")
            }else if( false  ){
                System.out.println("You can get permit yourself.")
            }
        ```
    * Some of the operators which are generally used in if conditions ares
        * __<__     (for comparing less than)
        * __>__     (for greater than)
        * __==__    (2 equlas to compare same)
        * __<=__    (less than or equal)
        * __>=__    (greater than or equal)
* __Modulus__ operator
    * __%__ operator gives the devision reminder 
    * example
    ```java
        int numner = 11;
        int reminder = number % 2;
        // The reminvider will be 1
        // You can use this to find a number is even or odd
    ```
