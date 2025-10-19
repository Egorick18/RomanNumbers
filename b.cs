using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RomanNumber;

RomanNumber num1 = new RomanNumber(15);
RomanNumber num2 = new RomanNumber("XIV");
RomanNumber num3 = new RomanNumber();

Console.WriteLine($"{num1} = {num1.IntValue}");
Console.WriteLine($"{num2} = {num2.IntValue}");
Console.WriteLine($"{num3} = {num3.IntValue}");

RomanNumber number = new RomanNumber(10);

Console.WriteLine(number.IntValue); 
Console.WriteLine(number.StringValue);
Console.WriteLine(number.ToString());

number.IntValue = 25;
Console.WriteLine(number);

number.StringValue = "XL";
Console.WriteLine(number.IntValue);

RomanNumber a = new RomanNumber(10);
RomanNumber b = new RomanNumber(3);

RomanNumber sum = a + b;
Console.WriteLine($"{a} + {b} = {sum}");

RomanNumber diff = a - b;
Console.WriteLine($"{a} - {b} = {diff}");

RomanNumber mult = a * b;
Console.WriteLine($"{a} * {b} = {mult}");

RomanNumber div = a / b;
Console.WriteLine($"{a} / {b} = {div}");

RomanNumber x = new RomanNumber(10);
RomanNumber y = new RomanNumber(15);
RomanNumber z = new RomanNumber(10);

Console.WriteLine($"{x} == {z}: {x == z}");
Console.WriteLine($"{x} == {y}: {x == y}");
Console.WriteLine($"{x} != {y}: {x != y}");
Console.WriteLine($"{x} < {y}: {x < y}");
Console.WriteLine($"{y} > {x}: {y > x}");
Console.WriteLine($"{x} <= {z}: {x <= z}");
Console.WriteLine($"{x} >= {z}: {x >= z}");

RomanNumber big = new RomanNumber(1994);
Console.WriteLine($"1994 = {big}");

RomanNumber fromRoman = new RomanNumber("MCMXCIV");
Console.WriteLine($"MCMXCIV = {fromRoman.IntValue}");

RomanNumber numA = new RomanNumber(7);
RomanNumber numB = new RomanNumber(7);
Console.WriteLine($"numA.Equals(numB): {numA.Equals(numB)}");