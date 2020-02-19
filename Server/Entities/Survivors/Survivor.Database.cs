using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using FiveZ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiveZ.Entities.Survivors
{
    public partial class Survivor
    {
        #region Methods
        public void UpdateFull()
        {
            if (!Utils.Util.CheckThread("UpdateFull"))
                return;

            if (!Exists)
                return;

            if (SurvivorData == null)
                return;

            SurvivorData.Health = Health;

            if (Vehicle != null && Vehicle.Exists)
            {
                SurvivorData.Location = new Location(Vehicle.Position, Vehicle.Rotation);
                ((VehicleHandler)Vehicle).UpdateInBackground();
            }

            SurvivorData.Location = new Location(Position, Rotation);

            Task.Run(async () => {
                if ((DateTime.Now - LastUpdate).Minutes >= 1)
                {
                    TimeSpent += (DateTime.Now - LastUpdate).Minutes;
                    LastUpdate = DateTime.Now;

                    var result = await Database.MongoDB.Update(SurvivorData, "players", SurvivorData._id);

                    if (result == null || result.MatchedCount == 0)
                        Alt.Server.LogWarning($"Update error for player {await this.GetNameAsync()}");
                }
            });
        }
        #endregion
    }
}
