#### Things learned today
* __CRC__
    * CRC means
        * __C__ Class
        * __R__ Responsibility
        * __C__ Collaboration
    * In a project every class has a name __C__ and some responsibilities __R__ (methods) and collobarates __C__ with other classes.
    * This is like your school project where group of students are assigned for a project , and each one of you do some work in that project and at the same time takes help(collaboration) with other students

    * TOH class CRC
        * Disk 
            * C Disk
            * R draws the tower
            * C None (does not interact with any other class)
        * Tower 
            * C Tower
            * R draw the tower, add disks, remove disks and give the disk back
            * C collaborates with Disk
        * Gamer
            * C Gamer
            * R creates initial setup, moves the disk from one tower to another tower, tells when the game is over
            * C collaborates with Tower, Disk

* Tower class constructor
    * We will be writing taking the __title__ in Tower class constructor
    * Remember special method __init__ is constructor in python
    ```python
            # Constructor. which will be called during construction
            # which is Tower("some title")
            def __init__(self, title):  
                self.disk_bag = []
                self.title = title      # automatially adding a property to object
    ```

    * Also we will remove __title__ from __draw__ method
    ```python
            def drawTitle(self):
                print(f"                    {self.title}")

            def draw(self):
                # pole
                self.drawPole()

                # drawing disks
                for disk in self.disk_bag:
                    disk.draw()

                # now base
                self.drawBase()

                # title now.
                self.drawTitle()
    ```
* We will introduce __Gamer__ class which does orchrastation of creation and moving disks
    * Gamer class
    ```python
            from tower import Tower
            from disk import Disk

            class Gamer:
                # constructor called during Gamer()
                def __init__(self):

                    # we create bag for towers
                    self.towers_bag = []

                    # create 
                    towerA = Tower("Tower-A")

                    # create disk
                    small  = Disk(4)
                    towerA.add_disk(small)

                    medium  = Disk(8)
                    towerA.add_disk(medium)

                    large  = Disk(12)
                    towerA.add_disk(large)

                    # put towerA in the bag
                    self.towers_bag.append(towerA)

                    towerB = Tower("Tower-B")
                    # put towerB in the bag
                    self.towers_bag.append(towerB)

                    towerC = Tower("Tower-C")
                    # put towerC in the bag
                    self.towers_bag.append(towerC)

                def draw(self):
                    # draw the towers from bag.
                    for tower in self.towers_bag:
                        tower.draw()
    ```
    * main.py will look like below
    ```python
            from gamer import Gamer

            # construcing gamer object
            # this will create 3 towers and draw then
            gamer = Gamer()
            gamer.draw()
    ```
* [Introducing Gamer](https://github.com/sairamaj/programmingclass/tree/master/pythontoh/Step6)
