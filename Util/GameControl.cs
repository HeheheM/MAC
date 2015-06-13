using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC.Util
{
    class GameControl
    {
        public static String version = "2 Revision 1";
        public static Obj_AI_Hero MyHero = ObjectManager.Player;

        public static void LoadPlugin()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            var champname = ObjectManager.Player.BaseSkinName;
            if (champname == "Vayne")
                new MAC.Plugin.Vayne();
            else if (champname == "Graves")
                new MAC.Plugin.Graves();
            else if (champname == "Jinx")
                new MAC.Plugin.Jinx();
            else
            {
                Game.PrintChat(MiscControl.stringColor(ObjectManager.Player.ChampionName, MiscControl.TableColor.Red) + " not found. Loading OrbWalker...");
                MiscControl.LoadOrbwalker();
            }

        private static void CurrentDomainOnUnhandledException(object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Console.WriteLine(((Exception)unhandledExceptionEventArgs.ExceptionObject).Message);
            Console.WriteLine(((Exception)unhandledExceptionEventArgs.ExceptionObject).Source);
            Console.WriteLine((string)unhandledExceptionEventArgs.ExceptionObject);
            Game.PrintChat("Fatal error occured!");
        }

        public class EnemyInfo
        {
            public Obj_AI_Hero Player;
            public int LastSeen;
            public int LastPinged;

            public EnemyInfo(Obj_AI_Hero player)
            {
                Player = player;
            }
        }

    }
}
