using LeagueSharp;
using MAC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC.Controller
{
    class ControllerHandler
    {
        /*
         Inicializa o MAC
         */
        public static void GameStart()
        {
            Events.Game.OnGameStart += OnGameStart;
            Game.PrintChat(MiscControl.stringColor("MAC , " + GameControl.version, MiscControl.TableColor.Gold));
            Game.PrintChat("Currently being developed by HeheheM");
        }

        /*
          Escreve os créditos
         */
        private static void Draw_Credits(EventArgs args)
        {
        }

        /*
          Metodo disparado ao iniciar o Jogo
         */
        private static void OnGameStart(EventArgs args)
        {
            try
            {
                Drawing.OnDraw += Draw_Credits;
            }
            catch (Exception)
            {
                Game.PrintChat("Failed to load credits.");
            }
        }
    }
}
