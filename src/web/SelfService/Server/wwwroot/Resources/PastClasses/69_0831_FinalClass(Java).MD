#### Things learned today
* __How use JDK classes to do show simple window__
    * Now the we know how to create a object and use its method all we need is to find appropriate classes in JDK to show the window and call methods to get job done.
    * We found __JFrame__ and __JPanel__ are the classes to do this stuff
    ```java
            // create frame
            JFrame frame = new JFrame();
            frame.setSize(1500, 1500);
            
            // set the title.
            frame.setTitle("Sairama Graphic App");

            // set default close window
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            
            // add panel to the frame
            JPanel panel = new JPanel();
            frame.add(panel);
            panel.setBackground(Color.BLUE);
            // show the window
            frame.setVisible(true);
    ```
* __Inheritance__
    * Inheritance in one word is __reuse__
    * This is another principle of Object Oriented Principles
    * The keyword to use in inheritance is __extends__
    * we are not going deep in to this in basic java
    * Here is the way you can extend exiting JFrame
    ```java
            public class MyCustomFrame extends JFrame {
                MyPanel panel;
                public MyCustomFrame() {
                    // setting the window size
                    this.setSize(1500, 1500);
                
                    // set the title.
                    this.setTitle("Sairama Graphic App");

                    // set default close window
                    this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                    
                    this.panel = new MyPanel();
                    
                    this.add(panel);
                    // show the window
                    this.setVisible(true);
                }
            }    
    ```
