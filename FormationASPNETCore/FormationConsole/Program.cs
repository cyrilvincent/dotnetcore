// See https://aka.ms/new-console-template for more information
using FormationConsole.Banque;
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

Point p1 = new Point { X=2, Y=4 };
Console.WriteLine(p1);
Rectangle r1 = new Rectangle();
r1.Width = 3;
r1.Length = 2;
// Rectangle r2 = new (4,3);
Rectangle r3 = new Rectangle { Length = 5, Width = 6, Point=p1 };
Rectangle r4 = new Rectangle { Length = 5, Width = 6, Point = new Point { X = 2, Y = 4 } };
r3.Point.Move(0, 2);
r3.Point = null;
r3.Point?.Move(0, 0);
double? toto = r3.Point?.X;
Square s1 = new Square(3);
Console.WriteLine(s1.Surface);
var rectangles = new List<Rectangle>
{
    r1, r3, r4, new Rectangle { Length = 2, Width = 3, Point=p1 }
};
var result = rectangles.Where(r => r.Surface < 15).OrderBy(r => r.Surface); //.Select(r => new Square(r.Length));
var result2 = rectangles.Where(r => r.Perimeter < 15).OrderBy(r => r.Surface);
result.Intersect(result2);
result.Except(result2);


rectangles.Sum(r => r.Surface);
foreach (Rectangle rectangle in result)
{
    Console.WriteLine($"Result: {rectangle}");
}

for(int i = 0; i < 100; i++)
{
    rectangles.Add(new Square(i));
}
// Compte en incrémentant le solde du compte
//Random rnd = new Random();
//Decimal d = rnd.Next(0,100);
//d = (Decimal)rnd.NextDouble(); // 0 et 1

// Sum, MAx, Min, filtrer par Surface pairs, Longueur > 10
// OrderBy









//Console.WriteLine(r1);
Console.WriteLine($"Surface r1: {r1.Surface}, Perimeter r1: {r1.Perimeter}");
Client client = new Client { Id = 1, Prenom = "Cyril", Nom = "Vincent", Telephone = "0622538762", Mail = "contact@cyrilvincent.com"  };
Compte c1 = new Compte(1, client, 100, "EUR", 0);
var c2 = new Compte { Devise = "EUR", Decouvert=100, Client=client };
c1.Crediter(100);
c2.Crediter(100);
c1.Debiter(50);
c1.Debiter(1000);
Console.WriteLine(c1.Client.Nom);
Console.WriteLine(c1.Transactions);
foreach (var transaction in c1.Transactions)
{
    Console.WriteLine(transaction.Id);
}
Console.WriteLine(c2.Client.Nom);
var c3 = new CompteEpargne(1, client, 100, "EUR", 0, 0.1m);
Console.WriteLine(c3.Interet);
Compte c4;
c4 = c3;
List<Compte> comptes = new List<Compte>();

var bank = new Bank();
bank.AddCompte(c1);
bank.AddCompte(c2);
bank.AddCompte(c3);
Console.WriteLine(bank.GetEncours());
Console.WriteLine(bank.GetInteretsEnCours());

//Counter count1 = new Counter();
//Counter count2 = new Counter();
//count1.Increment();
//count1.Increment();
//count2.Increment();
// Counter.Increment();
// Console.WriteLine($"Count1: {count1.GetValue()} Count2: {count2.GetValue()}");
// Counter.Value

comptes = new List<Compte>();
Random rnd = new Random();
rnd.Next(0, 100);

for (int i = 0; i < 100; i++)
{
    comptes.Add(new Compte((ulong)i, client, rnd.Next(0, 10000), "EUR"));
}

// Retourner les comptes dont le solde > 5000 .Count
// Retourner les comptes dont le solde > 5000 ET numero est pair
// Idem en + Trier les comptes par solde puis par id
// Retourner que les soldes < 5000 => que des doubles
// Retourner la moyenne des soldes des comptes 
// Retourner la moyenne des soldes pour les comptes dont le solde < 5000
// Tester une intersection entre 2 listes
// Tester Union
// Tester Except
// Bonus Retourner les comptes numéro 1 (First()) et afficher ses transactions






















