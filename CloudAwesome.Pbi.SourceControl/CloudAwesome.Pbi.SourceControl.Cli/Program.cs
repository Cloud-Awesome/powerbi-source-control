using System;

namespace CloudAwesome.Pbi.SourceControl.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = @"C:\Users\Oculu\OneDrive - Cloud Awesome\Work\Microsoft\Power BI\Sandbox Files\Sandbox_Dec_2020.pbit";
            var outputPath = @"C:\Users\Oculu\OneDrive - Cloud Awesome\Work\Microsoft\Power BI\Sandbox Files\Output";

            var tester = new Packager();
            tester.Pack(filepath, outputPath, false);
            
            Console.ReadKey();
        }
    }
}
