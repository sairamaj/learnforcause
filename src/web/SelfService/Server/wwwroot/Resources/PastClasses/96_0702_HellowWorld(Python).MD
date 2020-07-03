#### Things learned today

* Verify Python installed
    * At command prompt
        ```cmd
            python --version
        ```
        you should see python version as 3.x.x
* Verify Visual studio code
    * Launch Code ( or type Visaul studio code from windows)
        * See the Code applicaiton comes up

##### Visual Studio Code
This is the edidor we will be using for our python development.

* Open Folder
    * Create a python folder ( or open already create folder)
        * File -> Open Filder  ( short cut **Ctrl+K Ctrl+O** )
        * Click on Explorer icon( left navigation) (**Ctrl+B**)
        * You will __OPEN EDITORS__ which are list of files you already opened in the editor(right hand side)
        * You can open terminal (from Terminal menu on top) and then click new terminal or using short cut **Ctrl+~**
        * From File menu item check __Auto Save__ which saves automatically whenever you make any change in the editor
* You will see your opended foled name in left     navigation 
    * Here you can create new file , new folder and open the files

##### Python programming

* Hello world
    ``
    From Explorer window click New file called __hello.py__ and type the below lines in the edidor
    ```python
        print("hello")
    ```

    * Executing the above lines
        * At Command Prompt navigate to the folder where you have saved this hello.py
            ```cmd
                hello.py
            ```
            or
            ```cmd
                python hello.py
            ```
        * From terminal ( Ctrl+~)
            ```cmd
                hello.py
            ```
            ```cmd
                python hello.py
            ```
        * Analyzing above hello.py
            * the file name ends with __.py__ (extension)
            * __print__ is method or function (in programming world a method/function means it does something. Each function has special things to do. In this case it is printing to the console)
            * No semicolons
            * we will see more about functions in upcoming classes.
* Variables
    * You can declare variables like below
        ```python
            x = 10
            print(x)

            # this is my first comment

            # using string variables with double quotes
            x = "sai"
            print(x)

            # using string variables with single quotes
            # both single and double quotes work in python
            x = 'ram'
            print(x)

        ```            
    * Observations
        * variables can be assigned with value (you don't have to say what data type like in other programming languages)
        * They can be re assigned to different data types
* Indentiation
    * In python programming indentiation is very important
    * In above program all the lines were aligned on the same columns vertically
    * Wrong program
        ```python
            # not vertically aligned the below lines
            x = 10
              print('hello')
        ```
    * Correct programdr
        ```python
            # property aligned vertically the below lines
            x = 10
            print('hello')
        ```
* If conditional
    * If conditional is used to do different things b based on data. For example when you go to DMV the driver permit requirements are based on age. If you are younger than 15 , then you cannot get driver permit. These things can be expressed in programming with __if__ condition.

    ```python
        age = 10

        if age < 15:
            print('cannot get driver permit' )
        else:
            print('can get driver permit')
    ```
    * Observations
        * __if__ is keyword to used for conditions
        * in __age < 15__  you are comparing whether variable __age__ is __less than__ __15__
        * __<__ is compares left hand side with right hand side value and gives __YES__ (true) or __NO__ (false)
        * if YES then line below __if__ will execute
        * Here is the __indentation__ as the next line after if is done with spaces(or tab)
        * __if__ and __else__ are aligned vertically
        * The lines under __if__ and __else__ are moved to left with spaces( indentiation)
        * you can have multiple lines to execute like below
            ```python
              if age < 15:
                print('cannot get driver permit' )
                print('come back when you are 15 years old)
              else:
                print('can get driver permit')
            ```