using System;
using System.Collections.Generic;
using System.IO;
using Fidelity.Droid;
using Fidelity.Models;
using Fidelity.Services;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(Store))]
namespace Fidelity.Droid
{
    class CarteComparer : IComparer<Carte>
    {
        public int Compare(Carte x, Carte y)
        {
            return x.Nom.CompareTo(y.Nom);
        }
    }

    public class Store : ICardStore
    {
        public Carte[] LoadCartes()
        {

            if (!FileExists())
            {
                SaveCartes(new Carte[0]);
            }

            var path = CreatePathToFile("cards.json");
            var all = File.ReadAllText(path);
            try
            {

                var lst = JsonConvert.DeserializeObject<Carte[]>(all);

                Array.Sort(lst, new CarteComparer());


                return lst;
            }
            catch
            {
                return new Carte[0];
            }

        }

        public void SaveCartes(Carte[] lst)
        {
            var path = CreatePathToFile("cards.json");
            var all = JsonConvert.SerializeObject(lst);
            File.WriteAllText(path, all);
        }

        bool FileExists()
        {
            return File.Exists(CreatePathToFile("cards.json"));
        }

        string CreatePathToFile(string filename)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(docsPath, filename);
        }

    }
}