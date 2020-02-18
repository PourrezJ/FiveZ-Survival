using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Entities.Survivors
{
    public partial class Survivor
    {
        public void OpenPlayerMenu()
        {
            if (this.IsDead)
                return;

            Menu menu = new Menu("ID_MainMenu", this.Name, "Choisissez une option :");
            menu.BannerColor = new MenuColor(0, 0, 0, 0);
            menu.ItemSelectCallback = MainMenuManager;

            menu.Add(new MenuItem("Déconnecter", "", "ID_Disconnect", true));
            MenuManager.OpenMenu(this, menu);
        }

        private void MainMenuManager(IPlayer client, Menu menu, IMenuItem menuItem, int itemIndex)
        {
            if (menu.Id == "ID_MainMenu")
            {
                switch (menuItem.Id)
                {
                    default:
                        break;
                }
            }
        }
    }
}
