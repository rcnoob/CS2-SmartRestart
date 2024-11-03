﻿using Timer = System.Timers.Timer;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System.Timers;
using CounterStrikeSharp.API.Modules.Utils;

namespace SmartRestart
{
    public class SmartRestart : BasePlugin
    {
        public override string ModuleName => "CS2-SmartRestart";
        public override string ModuleVersion => $"1.0.0";
        public override string ModuleAuthor => "rc https://github.com/rcnoob/";
        public override string ModuleDescription => "Periodically restart the current map";
        private Timer restartTimer = new Timer(1800000); // 30 minutes
        private int playerCount;

        public override void Load(bool hotReload)
        {
            restartTimer.Start();
            restartTimer.Elapsed += OnRestartTimedEvent;
        }

        private void OnRestartTimedEvent(Object source, ElapsedEventArgs e)
        {
            Restart();
        }

        private void Restart()
        {
            Server.NextFrame(() => {
                playerCount = Utilities.GetPlayers().Count;
                if (!PlayersConnected())
                    Server.ExecuteCommand($"ds_workshop_changelevel {Server.MapName}");
                if(HoursOnline() >= 24.0)
                    Server.ExecuteCommand($"ds_workshop_changelevel {Server.MapName}");
                else if(HoursOnline() >= 23.0)
                    Server.PrintToChatAll($"{ChatColors.LightRed}Map will restart in 1 hour...");
            });
        }

        private double HoursOnline()
        {
            return Math.Round(Server.CurrentTime / 3600, 1, MidpointRounding.ToNegativeInfinity);
        }

        private bool PlayersConnected()
        {
            if (playerCount == 0)
                return true;
            else
                return false;
        }
    }
}