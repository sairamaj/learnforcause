#### Things learned today
* __Big disk going on to small disk problem__
    * Current game allows the big disk to go on to small disk during move operation
    * In order to fix this , the __Tower__ class __addDisk__ should be modified as it is the one adding disks
    * addDisk should consider the following
        * If no disks then allow the disk to add
        * Calculate the size of disk coming as input
        * Calculate the size of the current top disk
        * If input disk size is greater than current top disk then throw exception
        * Otherwise add the disk
        * Following code fixes this
        ```java
                void addDisk(Disk d) throws Exception {
                    
                    if( this.disks.size() == 0) {
                        this.disks.add(d);	// no disk exists, so any disk allowed.
                        return;
                    }
                    
                    // input_disk_size = get the input disk(d) size
                    // topDis = get the top disk
                    // topDiskSize = get top disk size
                    // if input disk size > topDisSize
                        // if input_disk_size > topDiskSize
                            // we should throw exception
                        // else
                            // we can add
                    int input_disk_size = d.getSize();
                    
                    int totalDisks = this.disks.size();
                    int topDiskIndex = totalDisks-1;
                    Disk topDisk = this.disks.get(topDiskIndex);
                    int topDiskSize = topDisk.getSize();
                    
                    if( input_disk_size > topDiskSize) {
                        Exception notAllowed;
                        notAllowed = new Exception("Tower " + this.name + " does not allow " + input_disk_size + " to come on to " + topDiskSize);
                        throw notAllowed;
                    }
                    
                    // now allowed , so add it.
                    this.disks.add(d);
                }
        ```
        * we need to fix __Gamer__ __setup__ method as this is calling adddDisk and now we are throwing exception
        * __Gamer__ __setup__ method will be changed to fix adding the disks in proper order
        * add __throws Exception__ to the method
        * changed the order of adding the disks to towerA
        ```java
                public void setup() throws Exception {
                    // Created Tower-A
                    
                    this.towers = new ArrayList<Tower>();
                    
                    Tower towerA = new Tower("Tower-A");

                    // larger disk
                    Disk large = new Disk(8);
                    towerA.addDisk(large);

                    Disk medium = new Disk(6);
                    towerA.addDisk(medium);

                    // smaller disk
                    Disk small = new Disk(4);
                    towerA.addDisk(small);

                    
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
    * Finding out the top disk
        * As we add disk to the bag (ArrayList) the first one added will be at index __0__
        * Second one will be at index __1__
        * Third one will be at index __2__
        * The disks will be like below
        ```cmd
                        ---------(2)
                    -----------------(1)
                ----------------------- (0)
        ```
        * The top index
            * Total disks -1
            * i.e if disks are 3: the top index : 2
            * if disks are 2: the top index: 1

    * Fixing the draw method
        * we need to fix the draw as the current drawing happening like below
        ```cmd
                ----------------------- (2)
                    -----------------(1)
                        ---------(0)
        ```
        * We need to draw the disk from the bag in reverse order
        ```java
                // drawing the disks starging from last one.
                for(int i=this.disks.size()-1; i >=0 ; i--) {
                    Disk d = this.disks.get(i);
                    d.draw();
                }
        ```
        * Now the disks appear in proper order
        ```cmd
                        ---------(2)
                    -----------------(1)
                ----------------------- (0)
        ```
    * Fixing the __removeDisk__ to remove the top disk
    ```java
            int totalDisks = this.disks.size();
            int topDiskIndex = totalDisks-1;
            Disk topDisk = this.disks.remove(topDiskIndex);
            return topDisk;
    ```
* Current state of the game is available [here](https://github.com/sairamaj/programmingclass/tree/master/javatoh/Step10/src)


