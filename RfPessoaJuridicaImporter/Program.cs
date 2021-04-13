using System.IO;

namespace RfPessoaJuridicaImporter
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Usage: RfPessoaJuridicaImporter.exe path_to_decompressed_files");
                return;
            }
            var filesToImport = Directory.GetFiles(args[0]);
            var m = new Cnpj();
            m.Run(filesToImport);
        }
    }
}
