import * as alt from 'alt-client';
import * as game from 'natives';
import * as apiext from './utils/ApiExtends';
import * as interaction from './Interactions';
import * as streamer from './Streamer';
import * as menuManager from './MenuManager';
import * as wheelManager from './WheelMenuManager';
import * as vehicle from './Vehicle';
import { OpenCharCreator } from './Creator';
import { Loading } from './models/Loading';
import { Subtitle } from './models/Subtitle';
import { HelpText } from './models/HelpText';
import { PlayerCustomInterface, PlayerCustomization } from './models/PlayerCustomization';

const init = async () => {

    apiext.initialize();
    streamer.initialize();
    menuManager.initialize();
    wheelManager.initialize();
    vehicle.initialize();

    for (var i: number = 0; i <= 5; i++)
        game.disableHospitalRestart(i, true);

    game.setPlayerHealthRechargeMultiplier(alt.Player.local.scriptID, 0);
    game.startAudioScene("FBI_HEIST_H5_MUTE_AMBIENCE_SCENE");
    game.cancelCurrentPoliceReport();
    game.clearAmbientZoneState("AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_GENERAL", true);
    game.clearAmbientZoneState("AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_WARNING", true);
    game.clearAmbientZoneState("AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_ALARM", true);
    game.clearAmbientZoneState("AZ_DISTANT_SASQUATCH", false);
    game.setAudioFlag("LoadMPData", true);
    game.setAudioFlag("DisableFlightMusic", true);
    game.setAudioFlag('PoliceScannerDisabled', true);
    game.pauseClock(true);
    game.setClockTime(8, 0, 0);

    game.setPedConfigFlag(alt.Player.local.scriptID, 35, false);
    game.setPedConfigFlag(alt.Player.local.scriptID, 184, false);
    game.setPedConfigFlag(alt.Player.local.scriptID, 429, true);

    game.setArtificialLightsState(true); // blackout
    game.setTimeScale(1);

    alt.setStat('stamina', 100);
    alt.setStat('strength', 100);
    alt.setStat('lung_capacity', 100);
    alt.setStat('wheelie_ability', 100);
    alt.setStat('flying_ability', 100);
    alt.setStat('shooting_ability', 100);
    alt.setStat('stealth_ability', 100);


    alt.everyTick(() => {
        if (game.isPauseMenuActive())
            return;

        game.drawRect(0, 0, 0, 0, 0, 0, 0, 0, false);

        if (Loading.loading != null)
            Loading.loading.Draw();
        if (Subtitle.subtitle != null)
            Subtitle.subtitle.Draw();
        if (HelpText.helpText != null)
            HelpText.helpText.Draw();

        for (let i = 12; i <= 19; i++)
            game.disableControlAction(2, i, true);

        disableSeatShuffle();
        interaction.onTick();
        streamer.onTick();
    });

    alt.on('keyup', (key) => {
        if (game.isPauseMenuActive())
            return;

        interaction.onKeyUp(key);
        menuManager.onKeyUp(key);
    });

    alt.on('keydown', (key) => {
        if (game.isPauseMenuActive())
            return;

        interaction.onKeyDown(key);
        menuManager.onKeyDown(key);
    });

    alt.onServer('OpenCreator', () => {
        OpenCharCreator();
    });

    alt.onServer('ApplyCharacter', (data: string) => {
        let char: PlayerCustomInterface = JSON.parse(data);
        char = new PlayerCustomization(char.Gender, char.Parents, char.Features, char.Appearance, char.Decorations, char.Hair, char.EyeColor);
        char.ApplyCharacter(alt.Player.local);
    });
};

function disableSeatShuffle() {
    if (!game.isPedInAnyVehicle(alt.Player.local.scriptID, undefined)) return;
    let vehicle = game.getVehiclePedIsIn(
        alt.Player.local.scriptID,
        undefined
    );

    let passenger = game.getPedInVehicleSeat(vehicle, 0, 0);

    if (!game.getIsTaskActive(passenger, 165)) return;

    if (game.isVehicleSeatFree(vehicle, -1, false)) {
        if (passenger === alt.Player.local.scriptID) {
            game.setPedIntoVehicle(alt.Player.local.scriptID, vehicle, 0);
        }
    }
}

init();