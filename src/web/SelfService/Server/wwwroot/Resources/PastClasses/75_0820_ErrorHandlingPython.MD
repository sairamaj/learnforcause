#### Things learned today
* __Moving disks from towers__
    * Lets introduce __move__ method in __Gamer__ to move disks
    * Moving is nothing but removing a disk from a tower and adding the same disk to another tower.
    ```python
            def move(self, from_tower, to_tower):
                # in program world the list indexes starts with 0
                # For user the towers are 1,2,3 and hence we will be reducing by 1 for whatever user entered.
                from_tower = from_tower-1
                to_tower = to_tower-1
                
                # get towers from the bag (list)
                towerFrom = self.towers_bag[from_tower]
                towerTo = self.towers_bag[to_tower]

                # Move (remove a disk from tower, and add to tower )
                disk = towerFrom.remove_disk()
                towerTo.add_disk(disk)

                # we are redrwing to show the new towers with disk
                self.draw()
    ```
* __Asking user input commands in while loop__
    * Now that towers are being drawn we need to ask the user to move the disks from a tower to another tower
    * We will be using __while__ loop to continuly asking the user through __input__ function
    * while loop syntax
    ```python
            while condition:
                # python statements
    ```
    * __input__ function to ask the user input
    ```python
            command = input("please enter command")
            print(f"You have entered {command}")
    ```
    * Lets combine these in our TOH program
    ```python
            keep_continue = True    # used for whether to be in the loop or not

            while keep_continue:
                command = input("please enter command:")
                
                if command == 'quit':
                    keep_continue = False   # this will make loop to terminated
                elif command == 'move':
                    from_tower = input('from which tower:')
                    to_tower = input('to which tower:')
                    
                    from_tower_int = int(from_tower)
                    to_tower_int = int(to_tower)

                    gamer.move(from_tower_int, to_tower_int)

                else:
                    print("invalid command(either enter move or quit")
    ```
* __Error handling Python__
    * What happens if user enteres a value which is not 1,2,3 for the tower number. 
    * What should happen?
    * User supposed to get an error saying that it is not valid and user should be still in asking
    mode
    * We can use __Exception__ using keyword __raise__ when any input is invalid.
    * A method can __raise__ if it cannot do its job, which cannot move when the tower number is invald.
    * Syntax for raising exception is
    ```python
            raise ValueError("you input is invalid")
    ```
    * When you call a method which can raise exception , one can use __except__ keyword to catch this and see what exactly contains a message.
    ```python
            try:
                # method which can raise exception
            except ValueError as e:
                print(f"    Error:{e}")
    ```
    * Lets implement exception in move method
    ```python
            # validate the input
            if from_tower < 1 or from_tower >3:
                raise  ValueError(f"from tower: {from_tower} should be between 1 and 3")
            
            if to_tower < 1 or to_tower >3:
                raise ValueError(f"to tower: {to_tower} should be between 1 and 3")
    ```
    * Catching this whie calling move method
    ```python
            try:
                gamer.move(from_tower_int, to_tower_int)
            except ValueError as e:
                print(f"    Error:{e}")
    ```

* [Code is available](https://github.com/sairamaj/programmingclass/tree/master/pythontoh/Step7)
