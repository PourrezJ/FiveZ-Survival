import * as alt from 'alt-client';
import * as game from 'natives';
import * as util from './utils/Util';
import * as enums from './utils/Enums';
//import * as chat from '../Chat/Chat';
import { Camera } from './models/Camera';

const playerPos: alt.Vector3 = {
    x: 1547.5,
    y: 6620,
    z: 1.404
};


export async function OpenCharCreator() {

    alt.log("OpenCharCreator");

    class HeadBlend {
        public ShapeFirst: number;
        public ShapeSecond: number;
        public ShapeThird: number;
        public SkinFirst: number;
        public SkinSecond: number;
        public SkinThird: number;
        public ShapeMix: number;
        public SkinMix: number;
        public ThirdMix: number;
    }

    alt.showCursor(true);
    //chat.hide(true);

    game.setClockTime(8, 0, 0);
    game.setOverrideWeather("Halloween");
    game.displayHud(false);
    game.displayRadar(false);
    game.setMouseCursorSprite(6);

    await util.LoadModelAsync('mp_m_freemode_01');
    await util.LoadModelAsync('mp_f_freemode_01');
    await util.LoadMovement("move_ped_crouched");

    game.setEntityCoords(alt.Player.local.scriptID, playerPos.x, playerPos.y, playerPos.z, false, false, false, false);
    game.setEntityHeading(alt.Player.local.scriptID, 180);
    game.freezeEntityPosition(alt.Player.local.scriptID, true);
    game.setPedHeadBlendData(alt.Player.local.scriptID, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);

    const camPos = util.PositionInFront({ x: playerPos.x + 0.8, y: playerPos.y + 0.8, z: playerPos.z +0.95 }, alt.Player.local.rot, -3.3);

    game.destroyAllCams(true);
    const camera = new Camera(camPos, util.ForwardVectorFromRotation(camPos));
    game.pointCamAtCoord(camera.Handle, camPos.x, camPos.y, camPos.z);
    camera.SetActiveCamera(true);

    game.renderScriptCams(true, false, 0, true, false, 0);

    alt.toggleGameControls(false);

    game.doScreenFadeIn(0);
}