using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace For_binary_tree
{
  
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();       
            string file = File.ReadAllText(@"C:\Users\Gleb-\Desktop\input.txt");
            string[] file_notes = file.Split('\n');
            for (int i = 0; i < file_notes.Length; i++)
            {
                file_notes[i] = file_notes[i].Replace("\r", string.Empty);
            }

            tree = FIleParser.Parse(file_notes);
            Console.ReadKey();
        }
    }
}
