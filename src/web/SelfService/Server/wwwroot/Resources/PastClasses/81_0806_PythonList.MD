#### Things learned today
* Multiple Files
    * So far we have been using single python file and we will be splitting the classes in to invidiual files
    *  Move __Disk__ into disk.py file
    *  Move __Tower__ into tower.py file.
    *  Rename the tower.py to __main.py__ file.
    *  Once you move you will get errors as the classes are in different files
    * There are 2 ways of fixing this
    * using __import__
    ```python
            import tower
            import disk

            # now to construct tower
            towerA = tower.Tower()
            # to construct disck
            small = disk.Disk()

            # Note: we have to use tower.Tower(prefix with file)
    ```
    * using __from__
    ```python
            from tower import Tower
            from disk import Disk

            # now to construct tower
            towerA = Tower()
            # to construct disck
            small = Disk()

            # note: in above we don't have to use tower.Tower or disk.Disk
        
    ```
* A bag data in python
    * A list (we can use as bag for our discussion purpose) can hold multiple values
    ```python
            fruits = []
            fruits.append('apple')
            fruits.append('banana')
            fruits.append('grape')
    ```
    * In above we have defined **fruits** and added 3 fruits in it through **append** method
    * To access all the fruits we can use __for__ loop
    ```python
            for fruit in fruits:
                print(f'you got {fruit}')
    ```
    * we can append any thing in this list
    * Below we are storing **Person** objects
    ```python
            class Person:
                def display(self):
                    print('displaying person')
            persons = []
            p1 = Person()
            persons.append(p1)
            p2 = Person()
            persons.append(p2)

            for person in persons:
                person.display()

    ```
* Using the __list__ in Tower of project
    * We are going to introduce the list of disks in tower
    * we are going to add a method **add_disk** in **Tower** class
    * **draw** method is going to loop through bag and uses **draw** method
    * from main we are going to add 3 disks only to towerA
    ```python
            class Tower:
                # constructor
                def __init__(self):
                    self.disk_bag = []      # add property disk_bag to the object (we can add properties at any time in the python)

                def add_disk(self, disk):
                    self.disk_bag.append(disk)
                
                def draw(self, title):
                    # pole
                    self.drawPole()

                    # drawing disks
                    for disk in self.disk_bag:
                        disk.draw()

                    # now base
                    self.drawBase()

                    # title now.
                    self.drawTitle(title)
    ```
    * in main.py
    ```python
                from tower import Tower
                from disk import Disk

                # object A
                towerA = Tower()

                # create disk
                small  = Disk(4)
                towerA.add_disk(small)

                medium  = Disk(8)
                towerA.add_disk(medium)

                large  = Disk(12)
                towerA.add_disk(large)

                # drawing which will draw 3 disks
                towerA.draw("Tower-A")
    ```
    * output will be
    ```cmd
                       |
                       |
                       |
                       |
                      XXX
                      XXXXXXX
                      XXXXXXXXXXX
           ---------------------
                    Tower-A
                       |
                       |
                       |
                       |
           ---------------------
                    Tower-B
                       |
                       |
                       |
                       |
           ---------------------
                    Tower-C    
    ```
* Moving a disk from towerA to towerB
    * moving is nothing but removing a disk from one tower and adding it to another tower
    * we can ask tower to remove the top disk 
    * we will add **remove_disk** in tower
    ```python
        class Tower:

            def remove_disk(self):
                topDisk = self.disk_bag[0]  # get top disk
                self.disk_bag.remove(topDisk)   # remove from the bag
                return topDisk  # give back this disk

    ```
    * in main to move from towerA to towerB
    ```python
            disk_from_tower = towerA.remove_disk()
            towerB.add_disk(disk_from_tower)

            # redraw as we have moved the disk
            towerA.draw("Tower-A")
            towerB.draw("Tower-B")
            towerC.draw("Tower-C")
    ```
    * output will be 
    ```cmd
                       |
                       |
                       |
                       |
                      XXXXXXX
                      XXXXXXXXXXX
           ---------------------
                    Tower-A
                       |
                       |
                       |
                       |
                      XXX
           ---------------------
                    Tower-B
                       |
                       |
                       |
                       |
           ---------------------
                    Tower-C    
    ```