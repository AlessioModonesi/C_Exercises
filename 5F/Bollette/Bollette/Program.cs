namespace Bolletta
{
    class Program
    {
        //istanza della bolletta
        private static Bolletta bolletta = new Bolletta();

        //istanze degli impianti
        private static Macchinari impianto = new Macchinari();
        private static Macchinari impiantoA = new Macchinari();

        //liste
        private static List<object> impianti = new List<object>();
        private static List<Bolletta> bollette = new List<Bolletta>();

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

        public static void CalcolaAltri()
        {
            foreach (Macchinari impianto in impianti)
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

                bolletta.SetMateria(materia);
                spesaIniziale = impianto.GetAcquistoInstallazione(); //prendo le spese d'acquisto e installazione
                bolletta.SetSpesaIniziale(spesaIniziale); //calcolo la spesa iniziale
                bolletta.TotaleAnnuale(); //calcolo il totale annuale
                bollette.Add(bolletta);
                bollette = bollette.OrderBy(bolletta => bolletta.GetTotaleAnnuale()).ToList();
            }

            Console.WriteLine("Bolletta migliore \n" + bollette[0]);
            Console.WriteLine("\nSe non hai spese iniziali: \nHai già la bolletta migliore! \n");
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
            //Console.WriteLine($"KWh: {KWh}, Smc: {Smc}"); //bloccato in caso di consumi custom
            InputScelta(scelta);

            switch (scelta)
            {
                case 1:
                    impiantoA = condensazione;
                    impianti = new List<object>() { tradizionale, stufa, pompa, eco };
                    break;
                case 2:
                    impiantoA = tradizionale;
                    impianti = new List<object>() { condensazione, stufa, pompa, eco };
                    break;
                case 3:
                    impiantoA = stufa;
                    impianti = new List<object>() { condensazione, tradizionale, pompa, eco };
                    break;
                case 4:
                    impiantoA = pompa;
                    impianti = new List<object>() { condensazione, tradizionale, stufa, eco };
                    break;
                case 5:
                    impiantoA = eco;
                    impianti = new List<object>() { condensazione, tradizionale, stufa, pompa };
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

            spesaIniziale = 0;
            bolletta.SetMateria(materia); //setto la materia utilizzata nella bolletta
            bolletta.SetSpesaIniziale(spesaIniziale); //calcolo la spesa iniziale
            bolletta.TotaleAnnuale(); //calcolo il totale annuale
            bollette.Add(bolletta);

            Console.WriteLine(bolletta.StampaAttuale()); //stampo la bolletta attuale
            Console.WriteLine("-----------------------------------\n");
            CalcolaAltri();
        }
    }
}