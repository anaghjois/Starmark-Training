using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworksApp.FileHandling
{
    class FileIOEX01
    {
            static void Main(string[] args)
            {
                string filename = "../../FileHandling/FileIOEX01.cs";
                if (File.Exists(filename))
                {
                    var content = File.ReadAllText(filename);
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("file doesn't exist");
                }
            }
        }

    }
