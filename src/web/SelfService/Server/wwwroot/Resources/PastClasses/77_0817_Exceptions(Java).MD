#### Things learned today
* __Exceptions__
    * When We play game now, we can see that one can give __from__ and __to__ towers to, whateever they want to give. But other than 1,2,3 everything is __not valid__. We need to modify the __move__ function to take care of these invalid inputs.
    This is where __Exceptions__ coming in to picture. Whenever a method __cannot do its job__ , then it should __tell__ whoever is calling this method __through exception__. Lets see how who we can take care of __move__ method.

    ```java
            if( from <0 || from >3 )
            {
                throw new Exception("FromTower:" + from + " should be between 1 and 3");
            }
            
            if( to < 0 || to >3) {
                // not allowed
                Exception toNotAllowed;
                toNotAllowed = new Exception("Totower:" + to + " is should be between 1 and 3");
                throw toNotAllowed;
            }
    ```

    * if you see above we are checking __from__ and __to__ to be invalid, when they are less than 0 and greater than 3. When this happens we use keyword __throw__, which means from here onwards the method will __abort__ futher process and tell caller that something __bad happended__.

    * Syntax of throwing exception
    ```java
            Exception variableName;     // declaring exception variable
            variableName = new Exception("some message");   // creating Exception object
            throw variableName;     // throwing exception object.
    ```
    * when a method is throwing exception its signature has to be changed.
    * Before throwing exception
    ```java
            void move(int from, int to){
            }
    ```
    * After adding throw in method (see throws Exception has been added)
    ```java
            void move(int from, int to) throws Exception {
            }
    ```    
    * This is saying that method __move__ will do moving the disks , but at the same can throw if something is not right. 

* __Catching Exceptions__
    * When you call a method and if the method is throwing exception then you can catch and findout the details about what went wrong.
    ```java
            try{
                g.move(from, to);
            }
            catch(Exception e) {
                System.out.println(e.getMessage());
            }    
    ```
    * in above we used __catch__ to get the __Exception__ object which was used in __move__ method using __throw__ keyword.
    * We get the same object here in __catch__
    * This object has details like the message which was set during __throw__
    * We can use the method __getMessage()__ method to get the actual messages stored in this object.

* __If tower does not have disks , we should give error to user if used in removing disk__
    * Lets say user selected a __from__  a tower where there are no disks
    * We should say to the user that no disks exists in the tower and hence cannot move
    * Only tower will know whether disks exists or not
    * We can use the same exceptions mechanism to send errors.
    ```java
            Disk removeDisk() throws Exception{
        
                // checks disks size 0 (means no disks)
                if( this.disks.size() == 0) {
                    // throw exceptions saying no disks
                    Exception noDisk;
                    noDisk = new Exception("Tower: " + this.name + " does not have any disks");
                    throw noDisk;
                }
    ```
    * __main__ calls __move__ on __Gamer__ object
    * __move__ calls __removeDisk__ on __Tower__ object
    * __removeDisk__ checks for disk size and __throw__ exception.
    * __main__ method while calling __move__ gets in to __catch__
    * in __catch__ we are showing the message in __Exception__ object.
