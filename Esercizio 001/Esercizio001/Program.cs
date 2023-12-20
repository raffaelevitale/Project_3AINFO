int somma = 0;
int n1 = 0;
int n2 = 0;
bool errore = false;

Console.WriteLine("Esecizio 1: somma di 2 Numeri ricevuti in input");
Console.WriteLine();

Console.WriteLine("Inserisci N1: \n");

try
{
    n1 = Convert.ToInt32(Console.ReadLine()); //uso la Convert.ToInt32 perche dall'input prendo dei caratteri e io ho bisogno dei numeri
}
catch (Exception ex)
{
    Console.WriteLine("Input non valido.");
    errore = true;
}
Console.WriteLine();

if (!errore)
{
    Console.WriteLine("Inserisci N2: \n");
    try
    {
        n2 = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine("Input non valido.");
        errore = true;
        Console.WriteLine(ex);
    }
}
Console.WriteLine();

if (!errore)
{
    somma = n1 + n2;
    Console.WriteLine();
    Console.WriteLine("La somma tra " + n1 + " e " + n2 + " vale " + somma);
}

Console.ReadKey();