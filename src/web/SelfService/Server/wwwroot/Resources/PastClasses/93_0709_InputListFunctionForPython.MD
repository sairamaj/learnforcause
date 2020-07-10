#### Things learned today
* input
    * used for getting the input from user
    ```python
        name = input("please enter your name:")
    ```
* print with formatting
    * you can use 'f' (formatting) with **print** like below
    ```python
        name = "sai"
        print(f'Hello {name} welcome')
    ```
    with __f__ in print function the variables in __{__ and __}__ will be replaced with its values

    the output will be 
    ```cmd
        Hello sai welcome
    ```
* list
    * list is used to hold a variable with multiple values.
    ```python
        hobbies = ['play', 'music', 'running']
    ```
* for
    * we can use for loop to do repetive tasks and also looping over the lists
    ```python
        for hobby in hobbies:
            print(f'my hobby is :{hobby}')
    ```
    * also for looping over given numbers we can use __range__ function like below
    ```python
        for x in range(1,10,1):
            print(x)
    ```
    __range__ function will  have **start**, **end** and **increment**. In above start=1, end=10 and increment=1
    
    the output will be
    ```cmd
        1
        2
        3
        4
        5
        6
        7
        8
        9
    ```
    * Writing a math table using for loop
    ```python
        table = 5
        for i in range(1,11,1):
            result = table * i
            print(f'{table} * {i} = {result}')
    ```
    ```cmd
        5 * 1 = 5
        5 * 2 = 10
        5 * 3 = 15
        5 * 4 = 20
        5 * 5 = 25
        5 * 6 = 30
        5 * 7 = 35
        5 * 8 = 40
        5 * 9 = 45
        5 * 10 = 50    
    ```

## Functions

### Action 
In general (not related to programming) we have actions happen all the time in our real life.
some of them are
* run
* run for 10 miles
* get coffee
* take money and get coffee

If you observe these actions can be grouped in to following categories
* Actions wont' take anything and does not give back anything
    * run, read, jog, play ( __action__:  __run__, __read__, __jog__, __play__)
* Actions take some inputs but does not give anything back
    * run 10 miles ( __action__ is __run__ and __input__ is __10 miles__)
* Action does not take anything but give back
    * Tell me how many miles you have run today ( __action__ is: __tell miles you have run__ and __output__ :  miles ran)
* Action take some input and also give back some output
    * If you go to Starbucks they take money and give coffee ( __action__ is: __get coffee__, __input__: money , __output__: coffee)


### Actions in Programming
Lets define these actions which are called __functions__ in python.

Previously we have wrriten math table like below
```python
table = 5
for i in range(1,11,1):
   result = table * i
   print(f'{table} * {i} = {result}')
```

If we want to write more than one table like we want to write 3 math tables then what we can do is write the above code in function like below
```python
# define how mytable do here.
def mytable(table):
   for i in range(1,11,1):
      result = table * i
      print(f'{table} * {i} = {result}')

# Use the my table with 3
mytable(3)

# Use the my table with 4
mytable(4)

# Use the my table with 5
mytable(5)

```

We will learn more about different kind of functions in next class.