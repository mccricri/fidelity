using System;
using System.Collections.ObjectModel;
using System.Linq;
using Fidelity.Models;
using Xamarin.Forms;

namespace Fidelity.Services
{
    class CardStore
    {
        private static ObservableCollection<Carte> db = new ObservableCollection<Carte>();

        public static ObservableCollection<Carte> GetAllCartes()
        {
            if (db.Count == 0)
            {
                Carte[] fromfile = DependencyService.Get<ICardStore>().LoadCartes();

                if (fromfile != null)
                {
                    foreach (var c in fromfile)
                    {
                        db.Add(c);
                    }
                }
            }

            return db;
        }

        public static void AddCarte(Carte c)
        {
            foreach (var item in db)
            {
                if (item.Id.Equals(c.Id))
                {
                    item.Nom = c.Nom;
                    item.CB = c.CB;
                    item.Type = c.Type;
                    SaveAllCartes();

                    return;
                }
            }

            // si y avait pas dans la boucle
            db.Add(c);
            SaveAllCartes();
        }

        public static Carte FindCarte(string id)
        {
            foreach (var item in db)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }

            return null;
        }

        internal static void DeleteCarte(Carte modCarte)
        {
            foreach (var item in db)
            {
                if (item.Id.Equals(modCarte.Id))
                {
                    db.Remove(item);

                    SaveAllCartes();

                    return;
                }
            }
        }

        private static void SaveAllCartes()
        {
            DependencyService.Get<ICardStore>().SaveCartes(db.ToArray());
        }

    }
}
