using System;
using System.Linq;
using System.Xml.Linq;

namespace linqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"..\..\..\..\LinqToXML\LinqToXML\MyTunes.xml"); //Local do arquivo/serviço

            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica")
                            on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new
                        {
                            MusicaId = m.Element("MusicaId").Value,
                            Musica = m.Element("Nome").Value,
                            Genero = g.Element("Nome").Value
                        };

            foreach (var musicaEgenero in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                    musicaEgenero.MusicaId,
                    musicaEgenero.Musica.PadRight(20),
                    musicaEgenero.Genero);
            }

            Console.ReadKey();
        }

    }
}
