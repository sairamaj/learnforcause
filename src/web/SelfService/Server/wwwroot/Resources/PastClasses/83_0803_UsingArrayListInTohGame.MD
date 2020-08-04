#### Things learned today
* We have learned ArrayList in past class and we will be using this in our Tower of Hanoi class
    * Tower class needs to have this bag (ArrayList<Disk>) to know what disks it has
    * In the begining we wil be giving first tower 3 disks and no disks to other towers
    * Tower class will draw the disks between pole and base by looking in to the bag and taking each disk and draw the disk.
    * If there are no disks in the bag then nothing will be drawn.

        ```java
                // we drew the pole
                drawPole();
                
                // Draw all disks in the bag.
                // If bag is empty then nothing will be drawn.
                for(Disk d : disks) {
                    d.draw();
                }
                
                // draw base 
                drawBase();

        ```
        * From application class we will give 3 disks to the first tower.
        ```java
                towerA = new Tower("Tower-A");

                // We are creating disk
                // Give to only Tower-A
                Disk small = new Disk(4);
                towerA.addDisk(small);

                Disk medium = new Disk(6);
                towerA.addDisk(medium);

                Disk large = new Disk(8);
                towerA.addDisk(large);

        ```
        * Output will be like below
        ```cmd
            |
            |
            |
            |
        XXXX
        XXXXXX
        XXXXXXXX
        ________________
        Tower-A
            |
            |
            |
            |
        ________________
        Tower-B
            |
            |
            |
            |
        ________________
        Tower-C
        ```

* __Gamer__ class
    * We will be introducing another class which acts as Conductor (think of music program where one directs the musicians)
    * This class responsibilities
        * draws the initial towers
        * moves the disks from one tower to another tower
        * will let us know when the game is done (if all the disks are moved to another tower)
    ```java
        public class Gamer {

            Tower towerA;
            Tower towerB;
            Tower towerC;

            // Sets up the initial towers.
            public void setUp() {
                // Created Tower-A
                
                towerA = new Tower("Tower-A");

                // We are creating disk
                // Give to only Tower-A
                Disk small = new Disk(4);
                towerA.addDisk(small);

                Disk medium = new Disk(6);
                towerA.addDisk(medium);

                Disk large = new Disk(8);
                towerA.addDisk(large);

                // we are drawing tower
                towerA.draw();

                towerB = new Tower("Tower-B");
                towerB.draw();
                

                towerC = new Tower("Tower-C");
                towerC.draw();
            }
            
            // Move a disk from given tower to tower.
            void move() {
                // For now we are moving always from towerA to towerB just for testing.

                // remove a disk from tower
                Disk topDisk = towerA.removeDisk();
                // add disk to another tower.
                towerB.addDisk(topDisk);
                // redraw
                
                towerA.draw();
                towerB.draw();
            }
        }
        
    ```

    * Application class in its __main__ method will create Gamer and call __setUp__ to draw initial one.
    ```java
        Gamer g = new Gamer();
		g.setUp();    
    ```

    * Next we will call __move__ method
    * For now we will call just one time this __move__ method to see whether disk is moved or not
    * In coming classes we will be doing this in a loop to ask from the user
    ```java

		System.out.println("Moving...");
		g.move();
		System.out.println("Moved");

    ``` 

    ```cmd
            |
            |
            |
            |
        XXXX
        XXXXXX
        XXXXXXXX
        ________________
        Tower-A
            |
            |
            |
            |
        ________________
        Tower-B
            |
            |
            |
            |
        ________________
        Tower-C
        Moving...
            |
            |
            |
            |
        XXXXXX
        XXXXXXXX
        ________________
        Tower-A
            |
            |
            |
            |
        XXXX
        ________________
        Tower-B
        Moved

    ```

