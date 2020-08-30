#### Things learned today
* __Consuming other python packages__
    * There are lot of python packages available on the internet which does lot of cool things. 
    * We need to know how to get those in to our programs.
    * Lets say we want to do some coloring to our disks
    * We need to find out whether any python package exists on the internet.
    * One such package is __colorama__ 
        * How we can get the name of the package?
        * [packages](https://pypi.org/) can be used to search.
        * One search revelaed this package __colorama__
    * Once we know the pacakge , we can consume like below
        * run the below command in your terminal
        ```cmd
                pip install colorama
        ```
        * The above command will bring the package
        * Now you can read the instructions how to use in the package provider [page](https://pypi.org/project/colorama/)
        * Create testcolor.py
        ```python
                from colorama import init
                from colorama import Fore, Back, Style

                init()
                print(Fore.RED + 'some red text')
                print(Fore.GREEN + 'some red text')
        ```
        * Run the testcolor.py and you will see the colored text


* Using __colorama__ in Disk
    * Lets create disks in color using __colorama__ package
    * Lets take color of the disk in constructor 
    ```python
            def __init__(self, size, color):
                self.size = size
                self.color = color
    ```
    * Use the color in draw method like below
    ```python
                print('                      ', end='')   # put some filler
                for x in range(1, self.size, 1):
                    # by specifying end we are saying don't go the next line after print.
                    print(self.color + 'X' , end='')
                # move the current cursor to the next line, so that our base will draw properly
                print(Fore.WHITE +'')   # put WHITE back so that it will reset to WHITE
    ```
    * While creating the disk in gamer pass the color
    ```python

                large = Disk(12, Fore.BLUE)
                towerA.add_disk(large)

                medium = Disk(8, Fore.RED)
                towerA.add_disk(medium)

                small = Disk(4,Fore.GREEN)
                towerA.add_disk(small)
    ```
    * We will see the tower with colors like below

        ![toh](../../images/toh_with_color.PNG)


* __Error checking while moving big disk in to small disk__
    * Currently our program allowing big disk on to small disk which is against the rule of game.
    * In order to fix this __add_disk__ should consider the following
        * If no disks then allow the disk to add
        * Calculate the size of disk coming as input
        * Calculate the size of the current top disk
        * If input disk size is greater than current top disk then __raise exception__
        * Otherwise add the disk
        * Following code fixes this
        ```python
                if len(self.disk_bag) == 0:
                    self.disk_bag.append(disk)  # if no disks , we can add any disk
                    return
                
                # get top disk size
                # get input disk size
                # if input disk size > top disk size
                    # raise error
                total_disks = len(self.disk_bag)
                top_disk = self.disk_bag[total_disks-1]
                top_disk_size = top_disk.get_size()
                coming_disk_size = disk.get_size()

                if coming_disk_size > top_disk_size:
                    raise ValueError(f"{self.title} disk:{coming_disk_size} cannot go on to {top_disk_size}")

                self.disk_bag.append(disk)
        ```
    * Once we have put the checks in add_disk, our __gamer__ constructor failing when we run the program. The reason is we are adding the disks to tower A in wrong order. We need to fix this by changing the constructor of gamer like below
    ```python
                large = Disk(12, Fore.BLUE)
                towerA.add_disk(large)

                medium = Disk(8, Fore.RED)
                towerA.add_disk(medium)

                small = Disk(4,Fore.GREEN)
                towerA.add_disk(small)
    ```
    * With the above change of adding the disk to start with larger, medium and small ,our draw method in tower drawing the disks in wrong order
    * The reason is when we add the disks to tower bag the , the large disk is at index 0, the medium at 1 and small at 2 like below
    ```cmd
                ----------------------- (0)    
                ------------ (1)    
                ------ (2)    
    ```
    * We need to draw in reverse order.
    * In Python for lists which we are using
    * To travel __forward__
    ```python
                for disk in self.disk_bag[]:    # walking forward
                    disk.draw()
    ```
    * To travel in __reverse__
    ```python
                for disk in self.disk_bag[::-1]:    # walking reverse
                    disk.draw()
    ```
    * See the __[::-1]__  which means start with last
    * This is called __slicing__ which we will learn in next class
    * Now our draw is good with the above fix
    ```cmd
            ------ (2)    
            ------------ (1)    
            ----------------------- (0)    
    ```

    * The __remove_disk__ is failing to remove top disk
    * We need to get top disk when removing disk
    * The top disk is at the last index like below
    ```cmd
            ------ (2)    
            ------------ (1)    
            ----------------------- (0)    
    ```
    * To get top index
        * Find out the total disks
        * top_index = total disks-1
        * use top_index from the bag (list)
    ```python
                def remove_disk(self):
                    if len(self.disk_bag) == 0:
                        raise ValueError(f'tower {self.title} does not have any disks to move.')

                    total_disks = len(self.disk_bag)
                    topDisk = self.disk_bag[total_disks-1]
                    self.disk_bag.remove(topDisk)
                    return topDisk
    ```

    
* [Code is available](https://github.com/sairamaj/programmingclass/tree/master/pythontoh/Step8)

