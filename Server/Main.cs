using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using FiveZ.Entities;
using FiveZ.Entities.Survivors;
using FiveZ.Utils;
using System;
using System.Threading;

namespace FiveZ
{
    public class Main : AsyncResource
    {
        public static int MainThreadId { get; private set; }

        public Main()
        {
            Console.WriteLine("Loading FiveZ Server...");   
        }

        public override void OnStart()
        {
            MainThreadId = Thread.CurrentThread.ManagedThreadId;

            if (!Database.MongoDB.Init())
            {
                Alt.Server.LogError("MongoDB loading error.");
                Util.Delay(30000, () => Environment.Exit(0));
                return;
            }

            WheelMenuManager.Init();
            MenuManager.Init();
            VehiclesManager.Init();
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
