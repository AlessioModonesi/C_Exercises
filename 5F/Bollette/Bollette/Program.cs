namespace Bolletta
{
    class Program
    {
        private static int scelta;
        private static string check = "";
        private static bool checkInput = false;
        private static double KWh = 2700, Smc = 1300, totKWh, totSmc;

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
                    "\nSeleziona un macchinario:\n" +
                    "1) Caldaia a condensazione\n" +
                    "2) Caldaia tradizionale\n" +
                    "3) Stufa elettrica\n" +
                    "4) Pompa di calore\n" +
                    "5) Pompa economica"
                );
                Console.Write("La tua scelta: ");
                check = Console.ReadLine();
                checkInput = int.TryParse(check, out scelta);
            } while (scelta < 1 || scelta > 5 || checkInput == false);
            return var;
        }

        static void Main(string[] args)
        {
            //istanze delle bollette
            BollettaGas gas = new BollettaGas();
            BollettaLuce luce = new BollettaLuce();

            //istanze dei macchinari
            Macchinari impianto = new Macchinari();
            CaldaiaC condensazione = new CaldaiaC();
            CaldaiaT tradizionale = new CaldaiaT();
            Stufa stufa = new Stufa();
            Pompa pompa = new Pompa();
            PompaEco eco = new PompaEco();

            //InputKWh(KWh);
            //InputSmc(Smc);
            Console.WriteLine($"KWh: {KWh}, Smc: {Smc}");
            InputScelta(scelta);

            totKWh = (Smc * impianto.potereCalorifico) + KWh;
            totSmc = (KWh / impianto.potereCalorifico) + Smc;

            switch (scelta)
            {
                case 1:
                    impianto = condensazione;
                    break;
                case 2:
                    impianto = tradizionale;
                    break;
                case 3:
                    impianto = stufa;
                    break;
                case 4:
                    impianto = pompa;
                    break;
                case 5:
                    impianto = eco;
                    break;
            }

            if (impianto.GetTipoConsumo() == "gas")
            {
                impianto.SetConsumoAnnuale(Smc); //setto il consumo annuale di gas
                impianto.UtilizzoAnnuale(KWh); //calcolo l'utilizzo annuale dell'impianto selezionato
            }

            if (impianto.GetTipoConsumo() == "luce")
            {
                impianto.SetConsumoAnnuale(KWh); //setto il consumo annuale di luce
                impianto.UtilizzoAnnuale(Smc); //calcolo l'utilizzo annuale dell'impianto selezionato
            }

            Console.WriteLine(impianto);
            impianto.TotaleAnnuale();
            //Console.WriteLine("\n" + bolletta);
        }
    }
}