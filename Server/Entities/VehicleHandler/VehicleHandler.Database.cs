﻿using AltV.Net;
using AltV.Net.Async;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FiveZ.Entities
{
    public partial class VehicleHandler
    {
        #region Fields
        private DateTime _lastUpdateRequest;
        private bool _updateWaiting = false;
        private int _nbUpdateRequests;
        private bool _cancelUpdate;
        #endregion

        #region Methods

        public void UpdateInBackground(bool updateLastUse = true, bool immediatePropertiesUpdate = false)
        {
            if (SpawnVeh)
                return;

            if (updateLastUse)
                VehicleData.LastUse = DateTime.Now;

            if (immediatePropertiesUpdate)
                VehicleData.UpdateProperties();

            _lastUpdateRequest = DateTime.Now;

            if (_updateWaiting)
            {
                _nbUpdateRequests++;
                return;
            }

            _updateWaiting = true;
            _cancelUpdate = false;
            _nbUpdateRequests = 1;

            Task.Run(async () =>
            {
                DateTime updateTime = _lastUpdateRequest.AddMilliseconds(Globals.SAVE_WAIT_TIME);

                while (DateTime.Now < updateTime && !_cancelUpdate)
                {
                    TimeSpan waitTime = updateTime - DateTime.Now;

                    if (waitTime.TotalMilliseconds < 1)
                        waitTime = new TimeSpan(0, 0, 0, 0, 1);

                    await Task.Delay((int)waitTime.TotalMilliseconds);
                    updateTime = _lastUpdateRequest.AddMilliseconds(Globals.SAVE_WAIT_TIME);
                }

                if (_cancelUpdate)
                    return;

                try
                {
                    if (VehicleData == null)
                        return;

                    await AltAsync.Do(()
                        => VehicleData.UpdateProperties());
                    var result = await Database.MongoDB.Update(this.VehicleData, "vehicles", VehicleData.Plate);

                    if (result.ModifiedCount == 0)
                        Alt.Server.LogError($"Update error for vehicle: {VehicleData.Plate} - Owner: {VehicleData.OwnerID}");

                    _updateWaiting = false;
                }
                catch (Exception ex)
                {
                    Alt.Server.LogError("VehicleHandler.UpdateInBackground(): " + ex);
                }
            });
        }

        public async Task<bool> RemoveInDatabase()
        {
            var result = await Database.MongoDB.Delete<VehicleHandler>("vehicles", VehicleData.Plate);
            return (result.DeletedCount != 0);
        }
        #endregion
    }
}
