#### Things learned today
* __GameUser introduction__
    * Our __main__ method became big and complex
    * This is where we can introduce some other class to give some responsibility
    * Lets create class __GameUser__ to interact with user.
    * GameUser (__C__) with interating with user as (__R__) and collaborating with Gamer (__C__) 
    * __Refactoring__
        * Refactoring is word used for splitting big functions in to smaller functions
        * Writing common logic (and repeated code) in to smaller functions
    * While moving in to gamer we will do refactor with new private functions
    ```java
            public class GameUser {
                
                private Gamer gamer;
                private int fromTower;
                private int toTower;
                
                GameUser(Gamer gamer){
                    this.gamer = gamer;
                }
                
                public void start() {
                    boolean quit = false;

                    do {
                        System.out.println("Please enter command(quit or move):");

                        Scanner scanner = new Scanner(System.in);
                        String command = scanner.next();

                        if (command.equals("move")) {
                            boolean isvalid = this.askForTowerNumbers();

                            if(isvalid == false) {
                                continue;		// it will go back to top
                            }
                            
                            boolean isDone = this.moveDisks();
                            if( isDone) {
                                quit = true;
                            }
                            
                        } else if (command.equals("quit")) {
                            quit = true;
                        } else {
                            System.out.println("wrong command(please enter move/quit");
                        }

                    } while (quit == false);
                    
                }
                
                private boolean askForTowerNumbers() {
                    
                    Scanner scanner = new Scanner(System.in);

                    System.out.print("Please enter from which tower, you want to move:");
                    try {
                        this.fromTower = scanner.nextInt();
                        System.out.print("Please enter to which tower, you want to move:");
                        this.toTower = scanner.nextInt();
                    } catch (java.util.InputMismatchException e) {
                        System.out.println("Please enter a number.");
                        return false;
                    }

                    return true;
                }
                
                private boolean moveDisks() {
                    
                    boolean isGameDone = false;
                    System.out.println("we are going to move:" + this.fromTower+ " to:" + this.toTower);
                    try {
                        isGameDone = this.gamer.move(this.fromTower, this.toTower);
                        if (isGameDone) {
                            System.out.println("---------------------");
                            int moveCount = this.gamer.getNumberOfMoves();
                            System.out.println("congratulations! :" + moveCount);
                            System.out.println("---------------------");
                        }
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                    
                    return isGameDone;

                }
            }
    ```
    * In above we have introduced
        * __Constructor__ to take Gamer as it collaborates with this
        * __askForTowerNumbers__ to ask tower numbers from user
        * __moveDisks__ to move the disks
        * __start__ which is __public__ and can be used outside the class, used to start interacting with user
    * In __askForTowerNumbers__ we have consider user inputting characters instead of numbers by catching exception, as nextInt() will throw exception if the user input was not a number like below
    ```java

            try {
                this.fromTower = scanner.nextInt();
                System.out.print("Please enter to which tower, you want to move:");
                this.toTower = scanner.nextInt();
            } catch (java.util.InputMismatchException e) {
                System.out.println("Please enter a number.");
                return false;
            }    
    ```
* __Refactoring in Tower class__
    * In tower class , the caculating the topDisk logic has been repeated everywhere
    * This is where refactoring comes in to picture
    *  Making this as separate method and using this is better idea
    ```java
            private Disk getTopDisk() {

                int totalDisks = this.disks.size();
                int topDiskIndex = totalDisks - 1;
                Disk topDisk = this.disks.get(topDiskIndex);
                return topDisk;
            }        
    ```
    * Similarly another method to see any disks exists or not
    ```java
            private boolean isAnyDisksExists() {
                if (this.disks.size() == 0) {
                    return false;
                }

                return true;
            }    
    ```

[The above code is available here](https://github.com/sairamaj/programmingclass/tree/master/javatoh/Step12/src)
