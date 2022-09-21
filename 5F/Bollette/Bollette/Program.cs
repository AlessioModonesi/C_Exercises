namespace Bolletta
{
    class Program
    {
        private static bool checkInput = false;
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
            string tmp;
            do
            {
                Console.Write(
                    "1: caldaia a condensazione\n" +
                    "2: caldaia tradizionale\n" +
                    "3: stufa elettrica\n" +
                    "4: pompa di calore\n" +
                    "5: pompa di calore eco\n"
                );
                tmp = Convert.ToString(Console.ReadLine());
                checkInput = int.TryParse(tmp, out scelta);
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

            CaldaiaC condensazione = new CaldaiaC();
            CaldaiaT tradizionale = new CaldaiaT();
            Stufa stufa = new Stufa();
            Pompa pompa = new Pompa();
            PompaEco eco = new PompaEco();

            switch (scelta)
            {
                case 1:
                    impianto = condensazione;
                    Console.Write(impianto);
                    break;
                case 2:
                    impianto = tradizionale;
                    Console.Write(impianto);
                    break;
                case 3:
                    impianto = stufa;
                    Console.Write(impianto);
                    break;
                case 4:
                    impianto = pompa;
                    Console.Write(impianto);
                    break;
                case 5:
                    impianto = eco;
                    Console.Write(impianto);
                    break;
            }
        }
    }
}