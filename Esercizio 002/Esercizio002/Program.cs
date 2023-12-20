int n1 = 0, n2 = 0;
char tipoOperazione = ' ';
double ris = 0.0;

bool errore = false;

Console.WriteLine("Esercizio 2: Input di 2 numeri INTERI con relativa operazione");
Console.WriteLine();

//Input NUMERO 1
do
{
    errore = false;
    Console.Write("Inserisci il primo numero: ");
    try
    {
        n1 = Convert.ToInt32(Console.ReadLine());
    }
    catch(Exception ex)
    {
        Console.WriteLine("Il numero non è valido");
        Console.WriteLine();
        errore = true;
    }
}
while(errore);

//Input NUMERO 2
do
{
    errore = false;
    Console.Write("Inserisci il secondo numero: ");
    try
    {
        n2 = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine("Il numero non è valido");
        Console.WriteLine();
        errore = true;
    }
}
while (errore);

//Input del Tipo Operazione
do
{
    errore = false;
    Console.Write("Inserisci il tipo operazione (+, -, *, /): ");
    try
    {
        tipoOperazione = Convert.ToChar(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine("Il tipo operazione non è valido");
        Console.WriteLine();
        errore = true;
    }

    if(!errore)
    {
        if(tipoOperazione != '+' && tipoOperazione != '-' && tipoOperazione != '*' && tipoOperazione != '/')
        {
            Console.WriteLine("Il tipo operazione non è +, -, *, /");
            Console.WriteLine();
            errore = true;
        }
    }
}
while (errore);

errore = false;

//Calcolo il Risultato
switch (tipoOperazione)
{
    case '+':
        //Somma
        ris = n1 + n2;
        break;
    case '-':
        //Sottrazione
        ris = n1 - n2;
        break;
    case '*':
        ris = n1 * n2;
        break;
    case '/':
        if (n2 == 0)
            errore = true;
        ris = (double)n1 / (double)n2; //cast
        break;
    default:
        break;
}

//Visualizzo il risultato

Console.WriteLine();

if (!errore)
    Console.WriteLine("Il risultato è: " + Math.Round(ris,4));
    //Console.WriteLine($"Il risultato è: {ris} "); interpolazione di stringhe
else
    Console.WriteLine("Impossibile visualizzare il risultato");

Console.ReadKey();