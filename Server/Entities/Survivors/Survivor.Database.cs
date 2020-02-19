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
        #region Fields
        private DateTime _lastUpdateRequest;
        private bool _updateWaiting = false;
        private int _nbUpdateRequests;
        #endregion

        #region Methods
        public void UpdateFull()
        {
            if (Utils.Util.CheckThread("UpdateFull"))
                return;

            if (!Exists)
                return;

            Health = Health;

            if (Vehicle != null && Vehicle.Exists)
            {
                SurvivorData.Location = new Location(Vehicle.Position, Vehicle.Rotation);
                ((VehicleHandler)Vehicle).UpdateInBackground();
            }

            SurvivorData.Location = new Location(Position, Rotation);

            if ((DateTime.Now - LastUpdate).Minutes >= 1)
            {
                TimeSpent += (DateTime.Now - LastUpdate).Minutes;
                LastUpdate = DateTime.Now;
            }

            UpdateInBackground();
        }

        public void UpdateInBackground()
        {
            _lastUpdateRequest = DateTime.Now;

            if (_updateWaiting)
            {
                _nbUpdateRequests++;
                return;
            }

            _updateWaiting = true;
            _nbUpdateRequests = 1;

            Task.Run(async () =>
            {
                DateTime updateTime = _lastUpdateRequest.AddMilliseconds(Globals.SAVE_WAIT_TIME);

                while (DateTime.Now < updateTime)
                {
                    TimeSpan waitTime = updateTime - DateTime.Now;

                    if (waitTime.TotalMilliseconds < 1)
                        waitTime = new TimeSpan(0, 0, 0, 0, 1);

                    await Task.Delay((int)waitTime.TotalMilliseconds);
                    updateTime = _lastUpdateRequest.AddMilliseconds(Globals.SAVE_WAIT_TIME);
                }

                try
                {
                    var result = await Database.MongoDB.Update(this, "players", SurvivorData._id, _nbUpdateRequests);

                    if (result.MatchedCount == 0)
                        Alt.Server.LogWarning($"Update error for player {await this.GetNameAsync()}");

                    _updateWaiting = false;
                }
                catch (Exception ex)
                {
                    Alt.Server.LogError($"PlayerHandler.UpdateInBackground()  {await this.GetNameAsync()} - {ex}");
                }
            });
        }
        #endregion
    }
}
