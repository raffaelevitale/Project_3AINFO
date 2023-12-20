using System;

namespace Esercizio_011
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Esercizio 11: Combinazione Segreta da Indovinare");

            int[] combinazione;
            //. . .
            var scelta = 0;
            var livDiff = 0;
            var t_NUMEleCmb =
                0; //Variabile ricavata in base alla scelta dell'utente, ci dice il numero di elementi della combinazione
            bool insOK = false, genOk = false;

            combinazione = new int[1];

            do
            {
                //Importo il menu
                disegnaMenu();
                scelta = Convert.ToInt32(Console.ReadLine());

                //Controllo la scelta dell'utente
                switch (scelta)
                {
                    case 1:
                        //Input del livello di Difficoltà
                        livDiff = inputLivDiff();
                        insOK = true;
                        break;
                    case 2:
                        if (insOK)
                        {
                            t_NUMEleCmb = livDiff + 2;
                            combinazione = new int[t_NUMEleCmb];
                            generaCombinazione(combinazione, t_NUMEleCmb);
                            genOk = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Devi prima inserire la Difficoltà!");
                        }

                        break;
                    case 3:
                        if (genOk)
                        {
                            indovina(combinazione, t_NUMEleCmb);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Devi prima generare la Combinazione Segreta!");
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

        private static void indovina(int[] vCmb, int lunCmb)
        {
            var vTentativi = new int[lunCmb];
            var validCmb = false;

            //Inizializzo Tentativi
            for (var i = 0; i < lunCmb; i++)
                vTentativi[i] = 0;

            do
            {
                //Disegno la Combinazione
                disegnaCombinazione(vCmb, lunCmb, vTentativi);

                //Inserisco i Tentativi
                inserisciTentativi(vTentativi, lunCmb);

                //Controllo i Tentativi
                validCmb = controlloTentativi(vTentativi, vCmb, lunCmb);
                
                if(validCmb)
                    disegnaCombinazione(vCmb, lunCmb, vTentativi);
            } while (!validCmb);
        }

        private static bool controlloTentativi(int[] vTen, int[] vCmb, int lunCmb)
        {
            var esito = true;
            var i = 0;

            while (vTen[i] == vTen[i] && i < lunCmb - 1)
                i++;
            if (vTen[i] != vCmb[i])
                esito = false;

            return esito;
        }

        private static void inserisciTentativi(int[] vTen, int lunCmb)
        {
            var nCol = 0;
            var c = ' ';

            //Input dei tentativi
            nCol = 7;
            for (var i = 0; i < lunCmb; i++)
            {
                //Mi posiziono in Colonan 7 - Riga 7
                Console.SetCursorPosition(nCol, 7);
                Console.Write(" ");
                Console.SetCursorPosition(nCol, 7);
                c = Convert.ToChar(Console.ReadKey().Key);
                vTen[i] = Convert.ToInt32(c) - 48;
                nCol += 4;
            }
        }

        private static void disegnaCombinazione(int[] vCmb, int lunCmb, int[] vTen)
        {
            // Disegna "Combinazione in base alla difficoltà"
            //Difficile
            // +-------------------+
            // | X | X | X | X | X |
            // +-------------------+
            // | ? | ? | ? | ? | ? | 
            // +-------------------+
            //Media
            // +----------------+
            // | X | X | X | X |
            // +----------------+
            // | ? | ? | ? | ? |
            // +----------------+
            //Facile
            // +------------+
            // | X | X | X |
            // +------------+
            // | ? | ? | ? |
            // +------------+

            Console.Clear();
            
            //Controllo la combinazione
            for(int i = 0; i < lunCmb; i++)
                Console.Write(vCmb[i] + " ");

            // Mi Posizone in Colonna 5 - Riga 4
            Console.SetCursorPosition(5, 4);
            // Aggiungo il Separatore
            disegnaStruttura(lunCmb);

            // Mi Posizone in Colonna 5 - Riga 5
            Console.SetCursorPosition(5, 5);
            Console.Write("|");
            for (var I = 0; I < lunCmb; I++)
            {
                if (vCmb[I] == vTen[I])
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" X ");

                Console.ResetColor();
                Console.Write("|");
            }

            Console.ResetColor();

            // Mi Posizone in Colonna 5 - Riga 6
            Console.SetCursorPosition(5, 6);
            disegnaStruttura(lunCmb);

            // Mi Posizone in Colonna 5 - Riga 7
            Console.SetCursorPosition(5, 7);
            Console.Write("|");
            for (var I = 0; I < lunCmb; I++) Console.Write(" ? |");

            // Mi Posizone in Colonna 5 - Riga 8
            Console.SetCursorPosition(5, 8);
            // Aggiungo il Separatore
            disegnaStruttura(lunCmb);
        }

        private static void disegnaStruttura(int lunCmb)
        {
            switch (lunCmb)
            {
                case 3:
                    Console.Write("+-----------+");
                    break;
                case 4:
                    Console.Write("+---------------+");
                    break;
                case 5:
                    Console.Write("+-------------------+");
                    break;
            }
        }

        private static void generaCombinazione(int[] v, int lun)
        {
            var rnd = new Random();

            for (var i = 0; i < lun; i++)
                v[i] = rnd.Next(1, 10);

            Console.WriteLine();
            Console.WriteLine("Combinazione Segreta Generata!");
        }

        private static int inputLivDiff()
        {
            var livDiff = 0;
            var errore = false;

            do
            {
                errore = false;
                Console.WriteLine();
                Console.Write("Insersci la Difficolta della combinazione (1 Facile - 2 Media - 3 Difficile) ==> ");
                try
                {
                    livDiff = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errore: {e.Message}");
                    errore = true;
                }

                if (!errore)
                    if (livDiff < 1 || livDiff > 3)
                    {
                        Console.WriteLine("Errore: La Difficoltà deve essere compresa tra 1 e 3!");
                        errore = true;
                    }
            } while (errore);

            return livDiff;
        }

        private static void disegnaMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1 - Inserisci la Difficoltà (1 - 2 - 3)");
            Console.WriteLine("2 - Genera Combinazione Segreta");
            Console.WriteLine("3 - Indovina la combinazione segreta");
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