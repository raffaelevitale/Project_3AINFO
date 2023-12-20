using System;

namespace Esercizio_012
{
    internal class Program
    {
        private const int nRigori = 10; // numero di rigori per squadra

        public static void Main(string[] args)
        {
            var scelta = 0; // variabile per la scelta del menu
            var simOk = false; // flag per verificare se la simulazione è stata effettuata

            var vRig1 = new int[nRigori]; // vettore dei rigori della squadra 1
            var vRig2 = new int[nRigori]; // vettore dei rigori della squadra 2

            do
            {
                visMenu();
                scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        simulazione(vRig1, vRig2);
                        Console.WriteLine();
                        Console.WriteLine("Simulazione avvenuta con successo");
                        simOk = true;
                        break;
                    case 2:
                        if (simOk)
                        {
                            visualizzaSimulazione(vRig1, vRig2);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Simulazione non effettuata");
                        }

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

                if (scelta != 0)
                    attesa();
            } while (scelta != 0);
        }

        private static void visMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Simulazione Calci di RIGORE");
            Console.WriteLine();
            Console.WriteLine("1 - Simula");
            Console.WriteLine("2 - Visualizza l'esito");
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

        private static void simulazione(int[] vSq1, int[] vSq2)
        {
            var rnd = new Random();
            int SqPlus;
            var numAiuti = nRigori / 3;
            var contAiuti = 0;
            /*
             * AIUTINO
             */
            SqPlus = rnd.Next(1, 3);
            //Simulo i vari Rigori
            // 0 = SBAGLIATO
            // 1 = PARATO
            // 2 = SEGNATO, GOAL!!
            for (var i = 0; i < nRigori; i++)
            {
                vSq1[i] = rnd.Next(0, 3);
                if (SqPlus == 1 && contAiuti < numAiuti && vSq1[i] == 1)
                {
                    vSq1[i]++;
                    contAiuti++;
                }

                vSq2[i] = rnd.Next(0, 3);
                if (SqPlus == 2 && contAiuti < numAiuti && vSq2[i] == 1)
                {
                    vSq2[i]++;
                    contAiuti++;
                }
            }
        }

        private static void visualizzaSimulazione(int[] vSq1, int[] vSq2)
        {
            Console.Clear();
            Console.SetCursorPosition(4, 3);
            Console.WriteLine("Risultati Rigori");

            //Disegno la struttura
            Console.SetCursorPosition(4, 5);
            disegnaStruttura();

            //Visualizzo i risultati dei rigori
            disegnaRigori(vSq1, vSq2);
        }

        private static void disegnaStruttura()
        {
            var nRip = 5 + 4 * nRigori; // numero di ripetizioni per disegnare la struttura

            Console.Write("+");
            for (var i = 0; i < nRip; i++)
                Console.Write("-");
            Console.Write("+");
        }

        private static void disegnaRigori(int[] vSq1, int[] vSq2)
        {
            var totSq1 = 0; // totale dei rigori segnati dalla squadra 1
            var totSq2 = 0; // totale dei rigori segnati dalla squadra 2

            //Riporto i valori della Squadra 1
            Console.SetCursorPosition(4, 6);
            Console.Write("| SQ1 |");

            for (var i = 0; i < nRigori; i++)
                detRigore(vSq1[i], ref totSq1);

            //Disegno la struttura
            Console.SetCursorPosition(4, 7);
            disegnaStruttura();

            //Riporto i valori della Squadra 2
            Console.SetCursorPosition(4, 8);
            Console.Write("| SQ2 |");

            for (var i = 0; i < nRigori; i++)
                detRigore(vSq2[i], ref totSq2);

            //Disegno la struttura
            Console.SetCursorPosition(4, 9);
            disegnaStruttura();

            Console.SetCursorPosition(4, 11);
            Console.Write("Risultato");

            Console.SetCursorPosition(4, 12);
            Console.Write($"SQ1: {totSq1}");

            Console.SetCursorPosition(4, 13);
            Console.Write($"SQ2: {totSq2}");

            Console.SetCursorPosition(4, 15);
            if (totSq1 == totSq2)
                Console.WriteLine("Nessuna Squadra Vince");
            else if (totSq1 > totSq2)
                Console.WriteLine("Vince la Squadra 1");
            else
                Console.WriteLine("Vince la Squadra 2");
        }

        private static void detRigore(int valRigore, ref int totale)
        {
            if (valRigore == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" X ");
            }
            else if (valRigore == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" P ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" O ");
            }

            Console.ResetColor();
            Console.Write("|");
            totale += valRigore;
        }
    }
}