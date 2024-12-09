// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!!!!!");
int i = 1;
int j = i++;
int k = ++i;
k = ++i * j++ - 2;

long l = i;
j = (int)l;

Console.WriteLine($"{i},{j},{k}");
Console.ReadLine();
