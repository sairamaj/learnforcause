#### Things learned today
* __Re adding the disk to from tower, in case of error while adding to, to tower__
    * We have taken care of big disk not to allow on small disk
    * But in the process we lost the disk
    * The reason we lost the disk is
        * To move, first we have removed disk __from__ tower
        * Then try to add disk to __to__ tower.
        * In case if addDisk throws exception , we did not add back the disk to __from__ tower.
    * Lets fix this issue
    ```java
                try {
                    toTower.addDisk(topDisk);
                }catch(Exception e) {
                    fromTower.addDisk(topDisk);
                    throw e;
                }
    ```
    * Above what we did is we had put __try__ and __catch__ block around __addDisk__
    * In __catch__ block we are __adding__ the disk back to __from__ tower
    * catch block will be executed only when addDisk throws exception.

* __Detecting the game is done__
    * As per the rules, when all disks are moved from towerA to any other tower , then our game is done
    * The only object knows at any point about the disks of all towers is the __Gamer__
    * In __move__ method we will check after each move whether towerB or towerC has 3 disks
    * We will modify __move__ method to return __boolean__ data type which indicates whether game is done or not
    ```java
            // we need to skip first tower 
            // we need to see whether tower-b or tower-c has 3 disks
            // thats why we start with index as 1
            for(int i=1; i< this.towers.size(); i++) {
                Tower t = this.towers.get(i);
                int diskCountOnTower = t.getDiskCount();
                if( diskCountOnTower == 3) {
                    return true;		// all the disks are moved.
                }
            }

            return false;		// game is not done yet.
    ``` 
    * __Application__ __main__ method should take move return value and inform the user
    ```java
                boolean isGameDone = g.move(from, to);
                if(isGameDone) {
                    System.out.println("---------------------");
                    System.out.println("congratulations! :");
                    System.out.println("---------------------");
                    quit = true;	// this will terminate the loop
                }
    ```
* __Counting the number of moves taken to finish the game__
    * We need to tell the user about how many steps he has taken to move
    * __Gamer__ can count in __move__ method each time user moves
    ```java
            int numberOfMoves;		// required to count the number of moves taken

            // Move a disk from given tower to tower.
            boolean move(int from, int to) throws Exception {

                // increment the numer of moves
                numberOfMoves++;
    ```
    * Lets create a method in Gamer , to give number of moves
    ```java
            int getNumberOfMoves() {
                return this.numberOfMoves;
            }
    ```
    * Lets inform the user in game is done about how many moves he/she has taken to finish the game
    ```java
            boolean isGameDone = g.move(from, to);
            if(isGameDone) {
                System.out.println("---------------------");
                int moveCount = g.getNumberOfMoves();
                System.out.println("congratulations! :" + moveCount);
                System.out.println("---------------------");
                quit = true;
            }
    ```

[The above code is available here](https://github.com/sairamaj/programmingclass/tree/master/javatoh/Step11/src)