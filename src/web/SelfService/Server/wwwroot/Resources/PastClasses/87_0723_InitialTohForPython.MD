#### Things learned today
* Today we started initial version Tower of honai 
    * Created method 
    ```python
        def drawPole():
            for x in range(1,5,1):
                print("      |")

        def drawBase():
            print('-------------')

        def drawTitle(title):
            print(f"   {title}")
        
        def drawTower(title):
            drawPole()
            drawBase()
            drawTitle(title)

        drawTower("Tower-A")
        drawTower("Tower-B")
        drawTower("Tower-C")
    ```
    * In above __drawTower__ calling drawPole, drawBase and drawTitle
    * we are taking the title is input and passing this to drawTitle which uses to print the title
    * We are calling 3 times to draw 3 towers

* Introducing classes 
    * In python we can have classes
    * A __class__ is unit of some properties and methods(actions)
    * A __class__  is like __blueprint__ where you plan
        * Thinks of a __blueprint__ to build the structures(like buildins, bridges) 
    * A __object__ is thing made out of __class__ (blueprint)
        * When draw __blueprint__ u did not have any structures
        * You need to build structures using blueprint
        * Think of __object__ building from __class__
        * You can make lot of __objects__ from __class__

* Classes in python
    * Syntax
    ```python
        class Person:
            def run():
                print('runnning')
    ```
    * above the keyword __class__ followed by the name __Person__ and then followed by colon __:__
    * Methods in the class will have indented to right

* Tower of Hanoi in class
    * Below is the same Toh we have written earlier using functions
    ```python
        class Tower:
            
            def drawPole(self):
                for x in range(1,5,1):
                    print('   |')
            
            def drawBase(self):
                print('---------------------')

            def drawTitle(self, title):
                print(f"   {title}")

            def draw(self, title):
                self.drawPole()
                self.drawBase()
                self.drawTitle(title)

        # object A
        towerA = Tower()
        towerA.draw("Tower-A")

        # object B
        towerB = Tower()
        towerB.draw("Tower-B")

        # object C
        towerC = Tower()
        towerC.draw("Tower-C")    
    ```
    * each method in class will have one parameter called __self__
    * we will learn more about this __self__ keyword in next class.
    * we have created the class __Tower__
    * created 3 objects
    * called method called draw
    

