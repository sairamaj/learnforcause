#### Things learned today
* __Adding ArrayList of Tower in Gamer__
    * We added tower bag (ArrayList) to Gamer like below
    ```java
            ArrayList<Tower> towers;

            public void setup() {
                this.towers = new ArrayList<Tower>();
                
                Tower towerA = new Tower("Tower-A");

                // We are creating disk
                // Give to only Tower-A
                Disk small = new Disk(4);
                towerA.addDisk(small);

                Disk medium = new Disk(6);
                towerA.addDisk(medium);

                Disk large = new Disk(8);
                towerA.addDisk(large);
                towers.add(towerA);		// add it our bag

                Tower towerB = new Tower("Tower-B");
                towers.add(towerB);		// add it our bag
                
                Tower towerC = new Tower("Tower-C");
                towers.add(towerC);	// add it our bag
                
                // go through bag , pick a tower, draw
                for(Tower t : towers) {
                    t.draw();
                }
            }
    ```
    * __We have to change the move to take __from__ tower and __to__ tower__
    ```java
            // Move a disk from given tower to tower.
            void move(int from, int to) {
                
                // The user enters tower numbers as 1,2,3
                // But the array list first one starts with 0
                // so we have to reduce by 1
                from = from-1;
                to = to-1;
                
                // Get the tower object
                Tower fromTower = this.towers.get(from);
                Tower toTower = this.towers.get(to);
                
                // Get the top disk from tower
                Disk topDisk = fromTower.removeDisk();
                // Add it to toTower
                toTower.addDisk(topDisk);
                
                // Redraw as we have moved disk
                for(Tower t : towers) {
                    t.draw();
                }		
            }
    ```
    * __Asking the user for from and to tower numbers__
    ```java

            System.out.print("Please enter from which tower, you want to move:");
            int from = scanner.nextInt();
            System.out.print("Please enter to which tower, you want to move:");
            int to = scanner.nextInt();
            
            System.out.println("we are going to move:" + from + " to:" + to);
            g.move(from, to);
    ```
* __Method overloading__
    * A class can have method with same name but different inputs
    [read here for more details](https://github.com/sairamaj/programmingclass/blob/master/sessions/Session14.MD#method-overloading)
