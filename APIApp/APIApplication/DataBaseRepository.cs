using System.Linq;
using System.Windows.Forms;

namespace APIApplication
{
    public class DataBaseRepository
    {
        #region AddTrainStaitons
        public void AddTrainStations(string name, ListBox l)
        {
            if (name == l.Text) { return; }
            using (var ctx = new TrainContex())
            {
                var result = (from u in ctx.TrainTable
                              where u.AdvertisedLocationName == name
                              select u).FirstOrDefault();

                if (result != null) { return; }

                if (l.Items.Count < 3)
                {
                    ctx.TrainTable.Add(
                            new TrainTable
                            {
                                AdvertisedLocationName = name
                            }
                        );
                    ctx.SaveChanges();
                }
                else
                {
                    ctx.TrainTable.Add(
                           new TrainTable
                           {
                               AdvertisedLocationName = name
                           }
                       );
                    ctx.SaveChanges();
                    var deleteTráinStation = ctx.TrainTable.FirstOrDefault();
                    ctx.TrainTable.Remove(deleteTráinStation);
                    ctx.SaveChanges();
                }
            }
        }
        #endregion

        #region LoadDeparture
        public void LoadDeparture(ListBox s)
        {
            using (var conDb = new TrainContex())
            {
                foreach (var item in conDb.TrainTable)
                {
                    s.Items.Add(item.AdvertisedLocationName);
                }
            }
        }
        #endregion
    }
}
