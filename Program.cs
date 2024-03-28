//Written for Infinite Crisis. https://steamcommunity.com/app/345520/
internal class Program
{
    static BinaryReader br;
    private static void Main(string[] args)
    {
        br = new(File.OpenRead(args[0]));

        if (new string(br.ReadChars(4)) != "AKPK")
            throw new System.Exception("Wrong file. Input a pck file from Infinite Crisis.");

        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        br.ReadInt32();
        int fileCount = br.ReadInt32();

        List<Subfile> subfiles = [];

        for (int i = 0; i < fileCount; i++)
        {
            subfiles.Add(new());
        }
        Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]));
        int n = 0;
        foreach (Subfile subfile in subfiles)
        {
            br.BaseStream.Position = subfile.offset;
            using FileStream fs = File.Create(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]) + "//" + n);
            BinaryWriter bw = new(fs);
            bw.Write(br.ReadBytes(subfile.size));
            bw.Close();
            fs.Close();
            n++;
        }
    }

    class Subfile
    {
        public int unknown1 = br.ReadInt32();
        public int unknown2 = br.ReadInt32();
        public int size = br.ReadInt32();
        public long offset = br.ReadInt64();
    }
}