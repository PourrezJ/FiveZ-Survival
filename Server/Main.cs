using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using FiveZ.Entities;
using FiveZ.Entities.Survivors;
using System;

namespace FiveZ
{
    class Main : AsyncResource
    {
        public const int GlobalDimension = 0;
        public const float StreamDistance = 500;

        public Main()
        {
            Console.WriteLine("Loading FiveZ Server...");   
        }

        public override void OnStart()
        {
            if (!Database.Mongodb.Init())
            {
                Alt.Server.LogError("MongoDB loading error.");
                return;
            }

            SurvivorsManager.Init();
            PlayerKeyHandler.Init();
            Streamer.Init();

            Console.WriteLine("Loaded FiveZ Server!");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopping FiveZ Server...");
        }

        public override void OnTick()
        {
            base.OnTick();
        }

        #region Factory
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new SurvivorsFactory();
        }
        #endregion
    }
}
