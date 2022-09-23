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
        private static List<object> altriImpianti;
        private static List<Bolletta> bollette;

        //variabili
        private static int scelta;
        private static string check = "";
        private static bool checkInput = false;
        private static double KWh = 2700, Smc = 1300, totKWh = 0, totSmc = 0, materia = 0;

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
                Console.Write("Il tuo impianto: ");
                check = Console.ReadLine();
                //check = Convert.ToString(1);
                checkInput = int.TryParse(check, out scelta);
            } while (scelta < 1 || scelta > 5 || checkInput == false);
            return var;
        }

        public static void CalcolaAltri()
        {
            foreach (Macchinari impianto in altriImpianti)
            {
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
                //Console.WriteLine(impianto);

                bolletta.SetMateria(materia);
                double spesa = impianto.GetAcquistoInstallazione(); //prendo le spese d'acquisto e installazione

                bolletta.TotaleAnnuale(); //calcolo il totale annuale
                bolletta.TotalePrimoAnno(spesa); //calcolo il totale primo anno aggiungendo le spese d'acquisto e installazione
                bolletta.TotaleTriennale(); //calcolo il totale triennale (che utilizzo per il confronto tra i vari impianti)

                List<Bolletta> bollette = new List<Bolletta>();
                bollette.Add(bolletta);

                bollette = bollette.OrderBy(bolletta => bolletta.GetTotaleTriennale()).ToList();
            }

            Console.WriteLine("Ordinate per convenienza triennale");
            foreach (Bolletta bolletta in bollette)
            {
                Console.WriteLine(bolletta);
                Console.WriteLine("-----------------------------------------------------\n");
            }
        }

        static void Main(string[] args)
        {
            Console.Clear(); //pulisco la console

            //istanze dei macchinari
            CaldaiaC condensazione = new CaldaiaC();
            CaldaiaT tradizionale = new CaldaiaT();
            Stufa stufa = new Stufa();
            Pompa pompa = new Pompa();
            PompaEco eco = new PompaEco();

            InputKWh(KWh);
            InputSmc(Smc);
            //Console.WriteLine($"KWh: {KWh}, Smc: {Smc}");
            Console.Clear(); //pulisco la console
            InputScelta(scelta);
            Console.Clear(); //pulisco la console

            totKWh = (Smc * impianto.potereCalorifico) + KWh;
            totSmc = (KWh / impianto.potereCalorifico) + Smc;

            switch (scelta)
            {
                case 1:
                    impiantoA = condensazione;
                    altriImpianti = new List<object>() { tradizionale, stufa, pompa, eco };
                    break;
                case 2:
                    impiantoA = tradizionale;
                    altriImpianti = new List<object>() { condensazione, stufa, pompa, eco };
                    break;
                case 3:
                    impiantoA = stufa;
                    altriImpianti = new List<object>() { condensazione, tradizionale, pompa, eco };
                    break;
                case 4:
                    impiantoA = pompa;
                    altriImpianti = new List<object>() { condensazione, tradizionale, stufa, eco };
                    break;
                case 5:
                    impiantoA = eco;
                    altriImpianti = new List<object>() { condensazione, tradizionale, stufa, pompa };
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
            //Console.WriteLine("\nImpianto attuale\n" + impiantoA);

            bolletta.SetMateria(materia); //setto la materia utilizzata nella bolletta
            bolletta.TotaleAnnuale(); //calcolo il totale annuale
            Console.WriteLine(bolletta.StampaAttuale()); //stampo la bolletta attuale

            CalcolaAltri();
        }
    }
}