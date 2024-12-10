// See https://aka.ms/new-console-template for more information
using FormationConsole.Geometry;
using System.Collections.Immutable;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;


// F5
// Commentaires CTRL+K C CTRL+K U pour décommenter
//Console.WriteLine("Hello, World!");
//Console.WriteLine("Ca marche ?");

//int i = 0;
////int j;
//// Console.WriteLine(j);
//double d = 3.14;
//bool b = true;
//double d2 = d;
//float f = 3.14f;
//decimal deci = 3.14m;
//char c = 'a';
//string s = "abcd";
//var s1 = "abcd";

//i = 3;
//int j = 3;
//b = i == j;

//i++;
//++i;
//j = ++i; // j=6
//j = i++; // j=6, i=7

//j = 0;
//i = 0;
//var res = i == 0 && j == 0;

//int res2 = i == 0 ? 99 : 101; // Si ? true : false

//Console.WriteLine(11.0 / 4);

//i = 0;
//j = i;
//i++;
//Console.WriteLine(i);
//Console.WriteLine(j);

//f = (float)d;
//i = 3;
//j = 2;
//var res3 = (double)i / j;
//Console.WriteLine(res3);
//d = 3.669;

//Console.WriteLine($"La valeur de i est {d:N2}");

//var saisie = Console.ReadLine();
//i = int.Parse(saisie);
//Console.WriteLine(i + 1);

////if (i < 10)
////{
////    Console.WriteLine("OK");
////}
////else
////{

////}

////for(i=0;i<10;i+=2)
////{
////    Console.WriteLine(i);
////}

//// Saisir un nombre : n
//// Afficher n! : 5! = 1*2*3*4*5, 1!=1, 0!=1
//// Bonus Fibonacci f(5) = f(4)+f(3) avec f(1)=1 et f(0)=0
//// 

////Console.Write("Saisir un nombre: ");
////var s = Console.ReadLine();
////int n = int.Parse(s);
////int facto = 1;
////for (int i=2; i<=n; i++)
////{
////    facto *= i;
////}
////Console.WriteLine($"{n}!={facto}");

////// Fibo
////var a = 1;
////var b = 0;
////var fibo = a;

////for (int i=2; i<=n; i++)
////{
////    fibo = a + b;
////    b = a;
////    a = fibo;
////}
////Console.WriteLine($"F({n})={fibo}");

////List<int> list = new List<int>();
////list.Add(1);
////list.Add(2);
//List<int> list2 = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
////foreach (int v in list2)
////{
////    Console.WriteLine(v);
////}

//// Créer une liste de 10 éléments
//// Multiplier toutes les valeurs de la liste (ne pas mettre 0)
//// Créer une 2ème liste contenant que les nombres pairs de la 1ere liste : {1,2,3,4} => {2,4}
//var result = 1;
//foreach (int v in list2)
//{
//    result *= v;
//}
//Console.WriteLine(result);

//var results = new List<int>();
//foreach (int v in list2)
//{
//    if (v % 2 == 0)
//    {
//        results.Add(v);
//    }
//}
//foreach (int v in results)
//{
//    Console.WriteLine(v);
//}

//int a = 1;
//int b = a;
//a++;
//Console.WriteLine($"{a} {b}");

//// Reference
//List<int> c = new () { 1 };
//List<int> d = c;
//c.Add(2);
//foreach (int v in c) Console.WriteLine(v);
//foreach (int v in d) Console.WriteLine(v);
//Console.WriteLine(c == d);

//// 2 distincts, same values, but different references
//List<int> e = new() { 1, 2 };
//List<int> f = new() { 1, 2 };
//Console.WriteLine(e == f);
//e = f;
//Console.WriteLine(e == f);

//// Clonage
//List<int> g = new() { 1 };
//List<int> h = new List<int>(g); // Clonage
//g.Add(2);
//foreach (int v in g) Console.WriteLine(v);
//foreach (int v in h) Console.WriteLine(v);
//Console.WriteLine(g == h);

//static double Add(double a, double b)
//{
//    return a + b;
//}

//static void Display(List<int> values)
//{
//    foreach (double v in values)
//    {
//        Console.Write($"{v} ");
//    }
//    Console.WriteLine();
//}

//Console.WriteLine(Add(2, 3));
//Display(list2);

//// Mettre fibonacci et factorielle dans une fonction
//// Bonus : bool is_prime(n) : Une nombre premier est divisible uniquement par 1 ET lui même
//// Tout nombre >= 2 est premier sauf s'il possède un diviseur entre 2 et n-1 => for 

//static int factorielle(int n)
//{
//    int facto = 1;
//    for (int i = 2; i <= n; i++)
//    {
//        facto *= i;
//    }
//    return facto;
//}

//static int fibo(int n)
//{
//    var a = 1;
//    var b = 0;
//    var fibo = a;

//    for (int i = 2; i <= n; i++)
//    {
//        fibo = a + b;
//        b = a;
//        a = fibo;
//    }
//    return fibo;
//}

//Console.WriteLine(factorielle(5));
//Console.WriteLine(fibo(5));


Rectangle r1 = new Rectangle();
Rectangle r2 = new (4,3);
var r3 = new Rectangle(5, 6);
Console.WriteLine(r1);
Console.WriteLine($"Surface r1: {r1.Surface()}, Perimeter r1: {r1.Perimeter()}");
















