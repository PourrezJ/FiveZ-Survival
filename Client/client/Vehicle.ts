import * as alt from 'alt-client';
import * as game from 'natives';

export function initialize() {
    alt.onServer('SetDoorState', setDoorState);
}

export function setDoorState(vehicle: alt.Vehicle, door: number, state: number, option: boolean) {
    switch (state) {
        case 0:
            game.setVehicleDoorShut(vehicle.scriptID, door, option);
            break;
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
            game.setVehicleDoorOpen(vehicle.scriptID, door, false, option);
            break;
        case 255:
            game.setVehicleDoorBroken(vehicle.scriptID, door, option);
            break;
    }

}