using System;
using System.Linq;


// loop from 1 to 5 including 5
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
// loop from 1 to 5 excluding 5
for (int i = 1; i < 5; i++)
{
    Console.WriteLine(i);
}



// *****Fundamentals 1 Assignment*****

// Loop that prints all values from 1-255.

for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

// Loop all values from 1-100 that are divisble by 3 or 5 but not both.

for (int i = 1; i < 101; i++)
{               
    if (i % 15 == 0)
    {
        continue;
    }
    else if (i % 3 == 0 || i % 5 == 0)
    {
    Console.WriteLine(i);
    }
}


// Print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5.

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0)
    {
        if (i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else
        {
            Console.WriteLine("Fizz");
        }
    }
    else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
}

// (Optional) If you used "for" loops for your solution, try doing the same with "while" loops.

int five = 5;
int Three = 3;
for (int i = 1; i< 101; i++)
{
    five--;
    three--;
    if (five == 0 && three == 0)
    {
        Console.WriteLine("FizzBuzz");
        three = 3;
        five = 5;

    }else if(five == 0)

    {
        Console.WriteLine("Buzz");
        five = 5;
    }else if (three == 0)
    {
        Console.WriteLine("Fizz");
        three = 3;
    }
}