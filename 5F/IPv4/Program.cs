// Set IP
string strIP = IPv4.SetIP();
// Convert IP octal string -> octal IP
byte[] IP = IPv4.OctalString_OctalIP(IP);

// Set CIDR
string strCIDR = IPv4.SetCIDR();
// Convert CIDR str -> int
int intCIDR = Convert.ToInt32(strCIDR);

// Get SM
byte[] SM = IPv4.GetSM(intCIDR);
// Get network
byte[] network = IPv4.GetNetwork(IP, SM);
// Get broadcast
byte[] broadcast = IPv4.GetBroadcast(network, intCIDR);
// Get host range
byte[][] hostRange = IPv4.GetHostRange(network, intCIDR);

Console.WriteLine($"IP: {IP}");
Console.WriteLine($"SM: {IPv4.OctalIP_OctalString(SM)}");
Console.WriteLine($"Network: {IPv4.OctalIP_OctalString(network)}");
Console.WriteLine($"Broadcast: {IPv4.OctalIP_OctalString(broadcast)}");
Console.WriteLine($"Range: {IPv4.OctalIP_OctalString(hostRange[0])} - {IPv4.OctalIP_OctalString(hostRange[1])}");