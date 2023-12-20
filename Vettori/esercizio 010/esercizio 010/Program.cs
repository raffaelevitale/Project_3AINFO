using System;

namespace esercizio_010
{
    internal class Program
    {
        private const int maxLenght = 100;

        public static void Main(string[] args)
        {
            Console.WriteLine("Esercizio 10: suddivisione di un vettore in pari e dispari");

            int[] v, vP, vD;
            int lun = 0, lunP = 0, lunD = 0;
            var scelta = 0;
            bool lunOk = false, carOk = false;

            //Inizializzo i vettori
            v = new int[1];
            vP = new int[1];
            vD = new int[1];

            do
            {
                //Importo il menu
                disegnaMenu();
                scelta = Convert.ToInt32(Console.ReadLine());

                //Controllo la scelta dell'utente
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("1 - Inserisci la lunghezza del vettore");
                        lun = inputLenght();
                        lunOk = true;
                        carOk = false;
                        break;
                    case 2:
                        //Carica del vettore
                        if (lunOk)
                        {
                            v = new int[lun];
                            caricaVet(v, lun);
                            carOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Devi prima inserire la lunghezza del vettore!");
                        }

                        break;
                    case 3:
                        if (carOk)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Vettore:");
                            stampaVet(v, lun);
                        }

                        break;
                    case 4: //Suddividi il Vettore in Pari e Dispari
                        if (carOk)
                        {
                            vP = new int[lun];
                            vD = new int[lun];
                            suddividiVettore(v, vP, vD, lun, ref lunP, ref lunD);

                            Console.WriteLine();
                            Console.WriteLine("Vettore Pari");
                            stampaVet(vP, lunP);

                            Console.WriteLine();
                            Console.WriteLine("Vettore Dispari");
                            stampaVet(vD, lunD);
                        }
                        else
                        {
                            Console.WriteLine("Devi prima caricare il vettore!");
                        }

                        break;
                    case 0:
                        Console.WriteLine("Esci...");
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Scelta non valida!");
                        break;
                }

                if (scelta != 0)
                    attesa();
            } while (scelta != 0);
        }

        private static void suddividiVettore(int[] v, int[] vP, int[] vD, int l, ref int lunP, ref int lunD)
        {
            lunP = 0;
            lunD = 0;

            for (var i = 0; i < l; i++)
                if (v[i] % 2 == 0)
                {
                    vP[lunP] = v[i];
                    lunP++;
                }
                else
                {
                    vD[lunD] = v[i];
                    lunD++;
                }

            Console.WriteLine();
            Console.WriteLine("Vettore Pari:");
            stampaVet(vP, lunP);
            Console.WriteLine();
            Console.WriteLine("Vettore Dispari:");
            stampaVet(vD, lunD);
        }

        private static void stampaVet(int[] v, int l)
        {
            for (var i = 0; i < l; i++)
                Console.Write(v[i] + " | ");
            Console.WriteLine();
        }

        private static void caricaVet(int[] v, int l)
        {
            var rnd = new Random();

            for (var i = 0; i < l; i++)
                v[i] = rnd.Next(1, 101);

            Console.WriteLine();
            Console.WriteLine("Vettore caricato!");
        }

        private static int inputLenght()
        {
            var lenght = 0;
            var errore = false;

            do
            {
                errore = false;
                Console.WriteLine();
                Console.Write($"Insersci la lunghezza del vettore (1 .. {maxLenght}): ");
                try
                {
                    lenght = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    errore = true;
                }

                if (!errore)
                    if (lenght < 1 || lenght > maxLenght)
                    {
                        Console.WriteLine($"La lunghezza deve essere compresa tra 1 e {maxLenght}");
                        errore = true;
                    }
            } while (errore);

            return lenght;
        }


        private static void disegnaMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1 - Inserisci la lunghezza del vettore");
            Console.WriteLine("2 - Carica il vettore");
            Console.WriteLine("3 - Visualizza il vettore");
            Console.WriteLine("4 - Suddividi il Vettore in Pari e Dispari");
            Console.WriteLine("0 - Esci");
            Console.WriteLine();
            Console.Write("Scelta => ");
        }

        private static void attesa()
        {
            Console.WriteLine();
            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}