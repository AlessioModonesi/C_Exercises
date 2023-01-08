class IPv4
{
    // Verifica che 'strIP' sia un IP valido
    public static bool CheckIP(string strIP)
    {
        string[] octIP = strIP.Split('.');

        if (octIP.Length != 4)
            return false;

        for (int i = 0; i < 4; i++)
            try
            {
                Convert.ToByte(octIP[i]);
            }
            catch
            {
                return false;
            }

        return true;
    }

    // Verifica che 'strCIDR' sia un CIDR valido
    public static bool CheckCIDR(string strCIDR)
    {
        int intCIDR;

        if (!Int32.TryParse(strCIDR, out intCIDR))
            return false;

        if (intCIDR < 1 || intCIDR > 32)
            return false;

        return true;
    }

    // Setta l'IP
    public static string SetIP()
    {
        Console.WriteLine("Inserisci un indirizzo IP");
        string strIP = Console.ReadLine();

        if (!IPv4.CheckIP(strIP))
        {
            Console.WriteLine("Indirizzo IP errato");
            return null;
        }
        else
            return strIP;
    }

    // Setta il CIDR
    public static string SetCIDR()
    {
        Console.WriteLine("Inserisci il CIDR");
        string strCIDR = Console.ReadLine();

        if (!IPv4.CheckCIDR(strCIDR))
        {
            Console.WriteLine("CIDR errato");
            return null;
        }
        else
            return strCIDR;
    }

    // Converte da octal string a octal IP
    // input -> strIP = "192.168.0.1";
    // output -> octIP = [192, 168, 0, 1];
    public static byte[] OctalString_OctalIP(string strIP)
    {
        byte[] octIP = new byte[4];
        string[] octStr = strIP.Split('.');

        for (int i = 0; i < 4; i++)
            octIP[i] = Convert.ToByte(octStr[i]);

        return octIP;
    }

    // Converte da octal IP a octal string
    // input -> octIP = [192, 168, 0, 1];
    // output -> strIP = "192.168.0.1";
    public static string OctalIP_OctalString(byte[] octIP)
    {
        string strIP = "";

        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
                strIP += strIP[i].ToString() + ".";
            else
                strIP += strIP[i].ToString();
        }

        return strIP;
    }

    // Converte da binary string a octal IP
    // input -> strIP = "11000000.10101000.00000000.00000001";
    // output -> octIP = [192, 168, 0, 1];
    public static byte[] BinaryString_OctalIP(string strIP)
    {
        byte[] octIP = new byte[4];
        string[] octStr = strIP.Split('.');

        for (int i = 0; i < 4; i++)
        {
            int x = 0;
            byte tot = 0;

            for (int j = 7; j >= 0; j--)
            {
                tot += (byte)(Convert.ToInt32(octStr[i][j] - '0') * Convert.ToInt32(Math.Pow(2, x)));
                x++;
            }
            octIP[i] = tot;
        }

        return octIP;
    }

    // Converte da octal IP a binary string
    // input -> octIP = [192, 168, 0, 1];
    // output -> strIP = "11000000.10101000.00000000.00000001";
    public static string OctalIP_BinaryString(byte[] octIP)
    {
        string[] octStr = new string[4];
        string strIP = "";
        int tmp = 0;

        for (int i = 0; i < 4; i++)
        {
            int num = Convert.ToInt32(octIP[i]);
            for (int j = 0; j < 8; j++)
            {
                tmp = num % 2;
                num /= 2;
                octStr[i] = tmp.ToString() + octStr[i];
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
                strIP += octStr[i] + ".";
            else
                strIP += octStr[i];
        }

        return strIP;
    }

    // Calcola la subnet mask in base al CIDR
    public static byte[] GetSM(int CIDR)
    {
        string strSM = "";
        string str0 = "";
        string str1 = "";

        for (int i = 0; i < CIDR; i++)
        {
            str1 += "1";
        }
        for (int i = 0; i < 32 - CIDR; i++)
        {
            str0 += "0";
        }

        string tmp = str1 + str0;

        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                strSM += "." + tmp[i];
            else
                strSM += tmp[i];
        }

        return IPv4.BinaryString_OctalIP(strSM);
    }

    // Calcola il network address in base all'IP e alla SM
    public static byte[] GetNetwork(byte[] byteIP, byte[] byteSM)
    {
        string strIP = IPv4.OctalIP_BinaryString(byteIP).Replace(".", "");
        string strSM = IPv4.OctalIP_BinaryString(byteSM).Replace(".", "");
        string strNetwork = "";

        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                strNetwork += "." + And(strIP[i], strSM[i]);
            else
                strNetwork += And(strIP[i], strSM[i]);
        }

        return IPv4.BinaryString_OctalIP(strNetwork);
    }

    // Calcola il broadcast in base al network address e al CIDR
    public static byte[] GetBroadcast(byte[] network, int CIDR)
    {
        string strIP = IPv4.OctalIP_BinaryString(network).Replace(".", "");
        string strBroadcast = "";

        for (int i = 0; i < CIDR; i++)
        {
            strBroadcast += strIP[i];
        }

        for (int i = 31; i >= CIDR; i--)
        {
            strBroadcast += "1";
        }

        return IPv4.OctalIP_OctalString(Dott(strBroadcast));
    }

    // Calcola l'host range in base al network address e al CIDR
    public static byte[][] GetHostRange(byte[] network, int CIDR)
    {
        byte[][] hostRange = new byte[2][];
        string strIP = IPv4.OctalIP_BinaryString(network).Replace(".", "");
        string strIP1 = "";
        string strIP2 = "";

        for (int i = 0; i < CIDR; i++)
        {
            strIP1 += strIP[i];
            strIP2 += strIP[i];
        }

        // Primo host
        for (int i = CIDR; i < 32; i++)
        {
            if (i == 31)
                strIP1 += "1";
            else
                strIP1 += "0";
        }
        strIP1 = Dott(strIP1);
        hostRange[0] = IPv4.BinaryString_OctalIP(strIP1);

        // Ultimo host
        for (int i = CIDR; i < 32; i++)
        {
            if (i == 31)
                strIP2 += "0";
            else
                strIP2 += "1";
        }
        strIP2 = Dott(strIP2);
        hostRange[1] = IPv4.BinaryString_OctalIP(strIP2);

        return hostRange;
    }

    // Formatta 'strIP' aggiungendo "."
    protected static string Dott(string strIP)
    {
        string res = "";

        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                res += "." + strIP[i];
            else
                res += strIP[i];
        }

        return res;
    }

    // Esegue l'operazione di AND
    protected static int And(char x, char y)
    {
        int res = Convert.ToInt32(x - '0') & Convert.ToInt32(y - '0');
        return res;
    }
}