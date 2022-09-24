namespace Bolletta
{
    class Program
    {
        //istanza della bolletta
        private static Bolletta bolletta = new Bolletta();

        //istanze degli impianti
        private static Macchinari impianto = new Macchinari();
        private static Macchinari impiantoA = new Macchinari();

        //liste & array
        private static List<object> listImpianti = new List<object>(); //lista di tutti gli impianti
        private static List<Bolletta> listBollette = new List<Bolletta>(); //lista di tutte le bollette
        private static List<Bolletta> listBollettaA = new List<Bolletta>(); //lista della bolletta attuale
        //private static string[] elencoMacchinari = new string[5] { "CaldaiaC", "CaldaiaT", "Stufa", "Pompa", "PompaEco" };

        //variabili
        private static int scelta;
        private static string check = "";
        private static bool checkInput = false;
        private static double KWh = 2700, Smc = 1300, materia, spesaIniziale;

        public static double InputKWh(double var)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in KWh: ");
                check = Console.ReadLine();
                checkInput = double.TryParse(check, out KWh);
            } while (KWh < 0 || checkInput == false);
            return var;
        }

        public static double InputSmc(double var)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in Smc: ");
                check = Console.ReadLine();
                checkInput = double.TryParse(check, out Smc);
            } while (Smc < 0 || checkInput == false);
            Console.WriteLine("\n-----------------------------------\n");
            return var;
        }

        public static int InputScelta(int var)
        {
            do
            {
                Console.WriteLine(
                    "Che impianto possiedi?\n" +
                    "1) Caldaia a condensazione\n" +
                    "2) Caldaia tradizionale\n" +
                    "3) Stufa elettrica\n" +
                    "4) Pompa di calore\n" +
                    "5) Pompa economica"
                );
                Console.Write("\nIl tuo impianto: ");
                check = Console.ReadLine();
                //check = Convert.ToString(1);
                checkInput = int.TryParse(check, out scelta);
            } while (scelta < 1 || scelta > 5 || checkInput == false);
            Console.WriteLine("\n-----------------------------------\n");
            return var;
        }

        public static void Confronta()
        {
            foreach (Macchinari impianto in listImpianti)
            {
                bolletta = new Bolletta();
                if (impianto.GetTipoConsumo() == "gas")
                {
                    impianto.SetCostoGas(); //setto il costo della materia
                    impianto.SetConsumoAnnuale(Smc); //setto il consumo annuale di gas
                    impianto.UtilizzoAnnuale(KWh); //calcolo l'utilizzo annuale dell'impianto selezionato
                }

                if (impianto.GetTipoConsumo() == "luce")
                {
                    impianto.SetCostoLuce(); //setto il costo della materia
                    impianto.SetConsumoAnnuale(KWh); //setto il consumo annuale di luce
                    impianto.UtilizzoAnnuale(Smc); //calcolo l'utilizzo annuale dell'impianto selezionato
                }

                materia = impianto.Totale(); //calcolo il totale annuale
                //Console.WriteLine($"Impianto: {impianto}\n\n{impianto.Info()}");
                //Console.WriteLine("\n-----------------------------------\n");

                bolletta.SetMateria(materia);
                spesaIniziale = impianto.GetAcquistoInstallazione(); //prendo le spese d'acquisto e installazione

                bolletta.TotaleAnnuale(); //calcolo il totale annuale
                bolletta.Decennale(); //calcolo il totale in 10 anni (comprese le spese iniziali)
                listBollette.Add(bolletta);

                //bollette = bollette.OrderBy(bolletta => bolletta.GetTotaleAnnuale()).ToList();
                listBollette = listBollette.OrderBy(bolletta => bolletta.GetDecennale()).ToList();
            }

            //Console.WriteLine($"Bolletta attuale {listBollettaA[0]} \nBolletta migliore {listBollette[0]}");
            //Console.WriteLine("-----------------------------------\n");

            if (listBollettaA[0].Equals(listBollette[0]))
                Console.WriteLine("Hai già la bolletta migliore!!!\n");
            else
                Console.WriteLine($"Bolletta migliore {listBollette[0]}\n" + $"Spesa iniziale: {spesaIniziale} €\n");

        }

        static void Main(string[] args)
        {
            Console.Clear();
            //istanze dei macchinari
            CaldaiaC condensazione = new CaldaiaC();
            CaldaiaT tradizionale = new CaldaiaT();
            Stufa stufa = new Stufa();
            Pompa pompa = new Pompa();
            PompaEco eco = new PompaEco();

            InputKWh(KWh); //sbloccato in caso di consumi custom
            InputSmc(Smc); //sbloccato in caso di consumi custom
            //Console.WriteLine($"KWh: {KWh}, Smc: {Smc} \n"); //bloccato in caso di consumi custom
            InputScelta(scelta);

            switch (scelta)
            {
                case 1:
                    impiantoA = condensazione;
                    break;
                case 2:
                    impiantoA = tradizionale;
                    break;
                case 3:
                    impiantoA = stufa;
                    break;
                case 4:
                    impiantoA = pompa;
                    break;
                case 5:
                    impiantoA = eco;
                    break;
            }

            if (impiantoA.GetTipoConsumo() == "gas")
            {
                impiantoA.SetCostoGas(); //setto il costo della materia
                impiantoA.SetConsumoAnnuale(Smc); //setto il consumo annuale di gas
                impiantoA.UtilizzoAnnuale(KWh); //calcolo l'utilizzo annuale dell'impianto selezionato
            }

            if (impiantoA.GetTipoConsumo() == "luce")
            {
                impiantoA.SetCostoLuce(); //setto il costo della materia
                impiantoA.SetConsumoAnnuale(KWh); //setto il consumo annuale di luce
                impiantoA.UtilizzoAnnuale(Smc); //calcolo l'utilizzo annuale dell'impianto selezionato
            }

            materia = impiantoA.Totale(); //calcolo il totale annuale
            Console.WriteLine($"{impiantoA} (attuale)\n\n{impiantoA.Info()}");

            bolletta.SetMateria(materia); //setto la materia utilizzata nella bolletta
            bolletta.TotaleAnnuale(); //calcolo il totale annuale
            bolletta.Decennale(); //calcolo il totale in 10 anni (comprese le spese iniziali)

            listBollettaA.Add(bolletta); //salvo la bolletta dentro ad una lista

            Console.WriteLine(bolletta.ToString()); //stampo la bolletta attuale
            Console.WriteLine("-----------------------------------\n");

            listImpianti = new List<object>() { condensazione, tradizionale, stufa, pompa, eco };
            Confronta();
        }
    }
}