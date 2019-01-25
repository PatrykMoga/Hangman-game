using HangmanLibrary.Models;
using System.Collections.Generic;
using System.IO;

namespace HangmanLibrary.FileGlossary
{
    public class FileGlossary : IGlossary
    {
        //Temporarily solution
        private readonly string _path = @".\Words.txt";
        public HashSet<string> Words { get; set; }
        public bool BeenUpdated { get; set; }

        public FileGlossary()
        {
            //_path = path;           
            Words = new HashSet<string>();

            using (var streamReader = new StreamReader(_path))
            {
                string line;             
                while ((line = streamReader.ReadLine()) != null)
                {
                    Words.Add(line.ToLower().Trim());
                }
            }
        }

        public void AddWord(string word)
        {
            using (var streamWriter = new StreamWriter(_path,true))
            {
                streamWriter.WriteLine(word.Trim());
            }

            BeenUpdated = true;
        }
    }
}
