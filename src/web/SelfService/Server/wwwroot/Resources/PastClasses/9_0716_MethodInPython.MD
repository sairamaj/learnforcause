#### Things learned today
* Methods 
    * They are actions and does something
    * Whenever you want to get something from your program you should think of methods (either using one or writing your own)
    * Each method
        * Name
        * Inputs (0 or more)
        * Output (1 output)
        * Does some instructions
* Method Syntax
    ```python
        def methodName(input1, input2, input3):
            # instruction-1
            print(input1)
            # instruction-2
            print(input2)
    ```
    __def__ keyword followed by __methodName__ and input goes between __(__ and __)__
    The instructions under method will be with a indentiation to the right

* Various examples of method
    * Method with no inputs and no ouptuts
    ```python
        def sayHello():
            print("hello")
        
        # call the method
        sayHello()
    ```
    * Method with one input and no ouptuts
    ```python
        def sayHello(name):
            print(f"hello {name}")
        
        # call the method
        sayHello('sai')
    ```
    * Method with no inputs and one output
    ```python
        def getGreetings():
            return "hello"
        
        # call the method
        message = getGreetings()
        print(message)
    ```

    * Method with one input and one output
    ```python
        def getGreetings(name):
            return f"hello {name}"
        
        # call the method
        message = getGreetings('sai')
        print(message)
    ```
    * Method with multiple inputs and one output
    ```python
        def getGreetings(name, message):
            return f"hello {name}, you said {message}"
        
        # call the method
        message = getGreetings('sai', 'how r u?')
        print(message)
    ```

* Methods using other methods

    A method can call other methods to some work. Like in all above examples standard python method __print__ is used our custom methods. Like this we can use any method (either standard python methods or our own methods)
    ```python
        def add(x,y):
            z = x+y
            return z

        def sub(x,y):
            z = x-y
            return z
        
        def crazyMath(x,y,z):
            ret = add(x,y)
            ret = sub(ret,z)
            return ret

        result = crazyMath(1,2,3)
        print(result)
    ```
