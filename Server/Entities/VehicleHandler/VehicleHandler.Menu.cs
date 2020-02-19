using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using FiveZ.Entities.Survivors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Entities
{
    public partial class VehicleHandler
    {
        public void OpenXtremMenu(Survivor client)
        {
            if (client == null || !client.Exists)
                return;

            XMenu xmenu = new XMenu("VehiculeMenu");
            xmenu.Callback = VehicleXMenuCallback;

            if (client.IsInVehicle)
            {
                /*
                xmenu.Add(LockState == VehicleLockState.Locked ? new XMenuItem("Déverrouiller", "Déverrouille le véhicule", "ID_LockUnlockVehicle", XMenuItemIcons.LOCK_OPEN_SOLID, false)
                     : new XMenuItem("Verrouiller", "Verrouille le véhicule", "ID_LockUnlockVehicle", XMenuItemIcons.LOCK_SOLID, false));*/

                if (client.IsInVehicle && client.Seat == 1)
                {
                    xmenu.Add(new XMenuItem($"{(client.Vehicle.EngineOn ? "Eteindre" : "Allumer")} le véhicule", "", "ID_Start", XMenuItemIcons.KEY_SOLID, executeCallback: true));

                    if (LockState == VehicleLockState.Unlocked)
                        xmenu.Add(new XMenuItem("Gestion des portes", "", "ID_Doors", XMenuItemIcons.DOOR_CLOSED_SOLID, executeCallback: true));
                }
            }

            xmenu.Add(new XMenuItem("Inventaire", "Ouvre l'inventaire du véhicule", "ID_OpenInventory", XMenuItemIcons.SUITCASE_SOLID, false));

            xmenu.OpenXMenu(client);
        }

        private void VehicleXMenuCallback(IPlayer client, XMenu menu, XMenuItem menuItem, int itemIndex, dynamic data)
        {
            if (!Exists)
                return;

            switch (menuItem.Id)
            {
                case "ID_Start":
                    VehicleData.EngineOn = !VehicleData.EngineOn;
                    UpdateInBackground();
                    WheelMenuManager.CloseMenu(client);
                    break;

                case "ID_Doors":
                    OpenDoorsMenu(client);
                    break;

                case "ID_frontLeft":
                    SetDoorState(client, VehicleDoor.DriverFront, (this.GetDoorState(VehicleDoor.DriverFront) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
                case "ID_frontRight":
                    SetDoorState(client, VehicleDoor.PassengerFront, (this.GetDoorState(VehicleDoor.PassengerFront) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
                case "ID_backLeft":
                    SetDoorState(client, VehicleDoor.DriverRear, (this.GetDoorState(VehicleDoor.DriverRear) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
                case "ID_backRight":
                    SetDoorState(client, VehicleDoor.PassengerRear, (this.GetDoorState(VehicleDoor.PassengerRear) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
                case "ID_hood":
                    SetDoorState(client, VehicleDoor.Hood, (this.GetDoorState(VehicleDoor.Hood) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
                case "ID_trunk":
                    SetDoorState(client, VehicleDoor.Trunk, (this.GetDoorState(VehicleDoor.Trunk) >= VehicleDoorState.OpenedLevel1 ? VehicleDoorState.Closed : VehicleDoorState.OpenedLevel7));
                    OpenDoorsMenu(client);
                    break;
            }
        }

        private void OpenDoorsMenu(IPlayer client)
        {
            XMenu menu = new XMenu("DoorMenu");
            menu.Callback = VehicleXMenuCallback;

            menu.Add(new XMenuItem("Porte avant gauche", "", "ID_frontLeft", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.DriverFront))));
            menu.Add(new XMenuItem("Porte avant droite", "", "ID_frontRight", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.PassengerFront))));
            menu.Add(new XMenuItem("Porte arrière gauche", "", "ID_backLeft", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.DriverRear))));
            menu.Add(new XMenuItem("Porte arrière droite", "", "ID_backRight", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.PassengerRear))));
            menu.Add(new XMenuItem("Capot", "", "ID_hood", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.Hood))));
            menu.Add(new XMenuItem("Coffre", "", "ID_trunk", GetXMenuIconDoor((VehicleDoorState)GetDoorState((byte)VehicleDoor.Trunk))));

            menu.OpenXMenu(client);
        }

        public XMenuItemIconDesc GetXMenuIconDoor(VehicleDoorState state)
        {
            if (state == VehicleDoorState.Closed)
                return XMenuItemIcons.DOOR_CLOSED_SOLID;
            else if (state > VehicleDoorState.Closed && state <= VehicleDoorState.OpenedLevel7)
                return XMenuItemIcons.DOOR_OPEN_SOLID;
            else if (state == VehicleDoorState.DoesNotExists)
                return XMenuItemIcons.BROKEN_IMAGE;

            return XMenuItemIcons.DEVICE_UNKNOWN;
        }
    }
}
