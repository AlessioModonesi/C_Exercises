// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class IPv4
{
    private byte[] ip_address;
    private byte[] subnet_mask;

    /// <summary>
    /// Assign the input parameter to the attribute of the ip_address class
    /// </summary>
    /// <param name="ip">Ip Address</param>
    public void Set_IPAddress(byte[] ip)
    { }

    /// <summary>
    /// Assign the input parameter to the attribute of the subnet_mask.
    /// OBS: Attributes of the class will be erased if previously assigned AND subnet parameter is wrong.
    /// </summary>
    /// <param name="sm">Subnet Mask</param>
    public void Set_Subnet_Mask(byte[] sm)
    { }

    /// <summary>
    /// Return the network adapter ip address
    /// </summary>
    /// <returns>Ip Address</returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_IPAddress()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_Subnet_Mask()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    public void Set_CIDR(int n)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int Get_CIDR()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool[,] Get_IP_Address_Bool()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool[,] Get_Subnet_Mask_Bool()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool Address_Initialization(params byte[] list)
    { throw new Exception(); }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="ottettoByte"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool[,] OctetByteToOctetBool(byte[] ottettoByte)
    { throw new Exception(); }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool[] ByteToBool(byte n)
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sm"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool Verify_Subnet_Mask(byte[] sm)
    { throw new Exception(); }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="bn"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static byte BoolToByte(bool[] bn)
    { throw new Exception(); }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="h1"></param>
    /// <param name="h2"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool SameNetwork(IPv4 h1, IPv4 h2)
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_First_Ip_Host()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_Last_Ip_Host()
    { throw new Exception(); }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_BroadCast()
    { throw new Exception(); }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public byte[] Get_NetID()
    { throw new Exception(); }
}