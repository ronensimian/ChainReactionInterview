using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace ChainReaction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dict = new Dictionary<int, double>();

                for (int i = 0; i <= 200; i++)
                {
                    var tempDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText($"block{i}.json"));
                    double nonce = Convert.ToDouble(tempDict["nonce"]);
                    dict.Add(i, nonce);
                }

                var myList = dict.ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                foreach (var value in myList)
                {
                    Console.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
