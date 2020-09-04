#### Things learned today
* __Fixing the disk disappear issue__
    * When we move a disk from tower to another tower and if the other tower raises exception becuase it cannot allow the disk (because big disk going on to small disk), the disk is disappearing
    * The reason is our move is removing the disk from Tower and then adding this disk to another tower
    * If second tower rejects adding disk we already removed disk from the first tower.
    * We need to catch this and re add back to the original tower
    ```python
            # Move (remove a disk from tower, and add to tower )
            disk = towerFrom.remove_disk()
            try:
                towerTo.add_disk(disk)
            except ValueError as e:
                towerFrom.add_disk(disk)    # put back to the original tower
                self.draw()
                raise 
    ```
* __Finishing the game__
    * When all disks were moved on to either 2nd or 3rd tower our game is done.
    * As __move__ is the one which is doing the moves, we can see whether any tower has 3 disks (other than first one as this is the one we started) and return __True__ to indicate that game is done.
    * Introduce __get_disks_count__ in tower
    ```python
            def get_numberof_disks(self):
                return len(self.disk_bag)
    ```
    * Checking in __move__
    ```python
            # get 2nd tower disk count
            if self.towers_bag[1].get_numberof_disks() == 3:
                return True  # we are done with game
            if self.towers_bag[2].get_numberof_disks() == 3:
                return True # we are done with game

            return False
    ```
    * Checking for True or False from move in main 
    * Showing to the user when game is done
    ```python
            try:
                is_game_done = gamer.move(from_tower_int, to_tower_int)
                if is_game_done:
                    print(f'Congratulations, you are done.')
                    keep_continue = False
            except ValueError as e:
                print(f"    Error:{e}")
    ```
    * __Counting the number of moves__
    * It would be nice to tell the user about how many moves he did to finish the game
    * We can do this again in __move__ method
    * Introduce __move_count__ in constructor
    ```python
            def __init__(self):

            self.move_count = 0 # introduce move count
    ```
    * Incrementing the counter in move method
    ```python
            self.move_count = self.move_count+1
    ```
    * Showing to the user when game is done
    ```python
            try:
                is_game_done = gamer.move(from_tower_int, to_tower_int)
                if is_game_done:
                    number_of_moves = gamer.get_move_count()
                    print(f'Congratulations, you are done, and your moves:{number_of_moves}')
                    keep_continue = False
            except ValueError as e:
                print(f"    Error:{e}")
    ```

[Code Available](https://github.com/sairamaj/programmingclass/tree/master/pythontoh/Step9)