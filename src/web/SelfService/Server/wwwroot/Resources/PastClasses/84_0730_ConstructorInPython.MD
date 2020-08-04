#### Things learned today
* __self__ parameter in class methods
    * Every method in class has a at least one parameter
    * The name of the variable does not matter but highly recommended to use name as __self__
    * This variable represents the obj itself.
    * Methods use to call other methods using __self__ keyword.
    ```python
        class Tower:
            def drawPole(self):
                for x in range(1,5,1):
                    print("_")
            def draw(self):
                self.drawPole()
    ```
    ![self](../../images/self.PNG)

* Constructor in Py 
    * Constructors are used to create object and set object properties while creating itself.
    * The method __ __init__ __n represents constructor in Python
    ```python
        class Disk:
            def __init__(self):
                print("this is constructor")
        
        small  = Disk()     # Here the method __init__ is called automatically
    ```
    * Passing parameters to the constructor
    ```python
        class Disk:
            def __init__(self, size):
                self.size = size        # here the size property is added to the object automatically
        
        small = Disk(4) # passing value 4 to as the value of size
    ```
    * Using the class properties in methods
    ```python
        class Disk:
            def __init__(self, size):
                self.size = size        # here the size property is added to the object automatically
            
            def draw(self):
                for x in range(1,self.size, 1):
                    print("X")
        small = Disk(4) # passing value 4 to as the value of size
    ```
* Optional parameters
    * Python method can take extra parameters
    * Let me give a real example to  understand what these extra parameters mean
        * If I ask you to read book
            * you are reading your __own choice__ of book for __10 mins__
        * If I ask you to read a particular book like __Harry Potter__ then
            * you are reding __Harry Potter__ book for __10 mins__
        * If I ask you to read __Harry Potter__ book for __30 mins__
            * you are reding __Harry Potter__ book for __30 mins__
    * If you observe the optional (extra) parameters are book name and minutes to read
    * If I don't specify then they are of your own choice
    * Here book name and time to read are optional parameters

* Lets use optional parameters in __print__
    * __print__ by default moves the cursor to the next line after printing
    ```python
        print('abc')
        print('xyz')
    ```
    * the output of the above wil be 
    ```cmd
        abc
        xyz
    ```
   * Using optional parameter __end__ to control the behavior
   ```python
    print('abc', end='')
    print('xyz')
   ```
   * the output will be 
   ```cmd
    abcxyz
   ```

* Use __end__ argument in __Disk__ class
    ```python
        class Disk:
            def __init__(self, size):
                self.size = size

            def draw(self):
                for x in range(1,self.size,1):
                    print('X')      # we are not using end
        
        small = Disk(4)
        small.draw()
    ```
    ```cmd
        X
        X
        X
    ```
    ```python
        class Disk:
            def __init__(self, size):
                self.size = size

            def draw(self):
                for x in range(1,self.size,1):
                    print('X', end='')      # we are using end
        
        small = Disk(4)
        small.draw()
    ```
    ```cmd
        XXX
    ```
