using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Teht2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Piste> lista = new List<Piste>();

            Piste a = new Piste("A", 1, 1);
            Piste b = new Piste("B", 2, 2);

            lista.Add(a);
            lista.Add(b);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            string json = JsonConvert.SerializeObject(lista);

            Console.WriteLine(json);

            FileStream stream = new FileStream
            (@"C:\\tmp\bindataTentti.bin", FileMode.Open);

            BinaryReader reader = new BinaryReader(stream);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
        
            Piste temp = default(Piste);
            while (reader != null && reader.BaseStream.Position <
                reader.BaseStream.Length)
            {
                temp = new Piste(reader.ReadString(),reader.ReadDouble(),reader.ReadDouble());
                lista.Add(temp);
            }
            string json2 = JsonConvert.SerializeObject(lista);

            Console.WriteLine(json2);
        }
    }
}
