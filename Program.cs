//Written for Infinite Crisis. https://steamcommunity.com/app/345520/
internal class Program
{
    static BinaryReader br;
    private static void Main(string[] args)
    {
        br = new(File.OpenRead(args[0]));

        if (new string(br.ReadChars(4)) != "AKPK")
            throw new System.Exception("Wrong file. Input a pck file from Infinite Crisis.");

        Infinite_Crisis_Extractor.PCK.Read();
    }
}