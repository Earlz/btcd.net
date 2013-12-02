using System;
using System.Collections.Generic;
using System.IO;

namespace Earlz.Btcd.LiveTester
{
    public class ConfigParser
    {
        string Filename;
        public ConfigParser(string file)
        {
            Filename = file;
        }
        public IList<KeyValuePair<string,string>> Read()
        {
            var list = new List<KeyValuePair<string,string>> ();
            using (var f=File.Open(Filename, FileMode.Open))
            {
                using (var reader=new StreamReader(f))
                {
                    while(!reader.EndOfStream)
                    {
                        var s = reader.ReadLine();
                        if(s.Trim().Length == 0)
                        {
                            continue;
                        }
                        var e = s.Split(new char[] { '=' });
                        list.Add(new KeyValuePair<string,string>(e[0].Trim(), e[1].Trim()));
                    }
                }
            }
            return list;
        }
    }
}

