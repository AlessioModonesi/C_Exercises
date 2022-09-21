namespace Bolletta
{
    class Program
    {
        private static bool checkInput;
        private static string consumi = "";
        private static int scelta = 0;
        private static double KWh = 0;
        private static double Smc = 0;
        private static double totKWh = 0;
        private static double totSmc = 0;

        public static double InputKWh(double val)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in KWh: ");
                consumi = Convert.ToString(Console.ReadLine());
                checkInput = double.TryParse(consumi, out KWh);
            } while (KWh < 0 || checkInput == false);
            return val;
        }

        public static double InputSmc(double val)
        {
            do
            {
                Console.Write("Inserisci il consumo annuo in Smc: ");
                consumi = Convert.ToString(Console.ReadLine());
                checkInput = double.TryParse(consumi, out Smc);
            } while (Smc < 0 || checkInput == false);
            return val;
        }

        public static int InputScelta(int val)
        {
            string s;
            do
            {
                Console.WriteLine("Scegli il tuo metodo di riscaldamento\n" +
                              "Premi 1 per la caldaia a condesazione\n" +
                              "Premi 2 per la caldaia tradizionale\n" +
                              "Premi 3 per la stufa elettrica\n" +
                              "Premi 4 per la pompa di calore economica\n" +
                              "Premi 5 per pompa di calore di buon livello\n");
                s = Convert.ToString(Console.ReadLine());
                checkInput = int.TryParse(s, out scelta);
            } while (scelta < 1 || scelta > 5 || checkInput == false);
            return val;
        }

        static void Main(string[] args)
        {
            Bolletta bolletta = new Bolletta();
            Macchinari impianto = new Macchinari();

            InputKWh(KWh);
            InputSmc(Smc);

            totKWh = (Smc * impianto.pt) + KWh;
            totSmc = (KWh / impianto.pt) + Smc;

            InputScelta(scelta);

            CaldaiaCondensazione condensazione = new CaldaiaCondensazione();
            CaldaiaTradizionale tradizionale = new CaldaiaTradizionale();
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
        }
    }
}