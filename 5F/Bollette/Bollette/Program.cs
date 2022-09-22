namespace Bolletta
{
    class Program
    {
        private static bool checkInput = false;
        private static string consumi = "";
        private static int scelta = 0;
        private static double KWh = 2700;
        private static double Smc = 1300;
        private static double totKWh = 0;
        private static double totSmc = 0;

        public static double InputKWh(double val)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in KWh: ");
                consumi = Console.ReadLine();
                checkInput = double.TryParse(consumi, out KWh);
            } while (KWh < 0 || checkInput == false);
            return val;
        }

        public static double InputSmc(double val)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in Smc: ");
                consumi = Console.ReadLine();
                checkInput = double.TryParse(consumi, out Smc);
            } while (Smc < 0 || checkInput == false);
            return val;
        }

        public static int InputScelta(int val)
        {
            string tmp;
            do
            {
                Console.Write(
                    "\nSeleziona un macchinario:\n" +
                    "1) Caldaia a condensazione\n" +
                    "2) Caldaia tradizionale\n" +
                    "3) Stufa elettrica\n" +
                    "4) Pompa di calore\n" +
                    "5) Pompa di calore eco\n"
                );
                tmp = Console.ReadLine();
                checkInput = int.TryParse(tmp, out scelta);
            } while (scelta < 1 || scelta > 5 || checkInput == false);
            return val;
        }

        static void Main(string[] args)
        {
            Bolletta bolletta = new Bolletta();
            Macchinari impianto = new Macchinari();

            //InputKWh(KWh);
            //InputSmc(Smc);
            Console.WriteLine("KWh: " + KWh);
            Console.WriteLine("Smc: " + Smc);
            InputScelta(scelta);

            totKWh = (Smc * impianto.pt) + KWh;
            totSmc = (KWh / impianto.pt) + Smc;

            CaldaiaC condensazione = new CaldaiaC();
            CaldaiaT tradizionale = new CaldaiaT();
            Stufa stufa = new Stufa();
            Pompa pompa = new Pompa();
            PompaEco eco = new PompaEco();

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
                impianto.SetConsumo(Smc);
                impianto.Utilizzo(KWh);
            }
            else
            {
                impianto.SetConsumo(KWh);
                impianto.Utilizzo(Smc);
            }

            impianto.TotaleAnnuale();
            //Console.WriteLine("\n" + bolletta);
        }
    }
}