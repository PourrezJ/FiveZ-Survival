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

    let camPos = util.PositionInFront({ x: playerPos.x + 0.8, y: playerPos.y + 0.8, z: playerPos.z +0.95 }, alt.Player.local.rot, -3.3);

    game.destroyAllCams(true);
    const camera = new Camera(camPos, util.ForwardVectorFromRotation(camPos));
    game.pointCamAtCoord(camera.Handle, camPos.x, camPos.y, camPos.z);
    camera.SetActiveCamera(true);

    game.renderScriptCams(true, false, 0, true, false, 0);

    const view = new alt.WebView("http://resource/client/cef/charcreator/index.html", true);
    view.focus();

    alt.toggleGameControls(false);

    view.on('CreatorLoad', () => {
        alt.setTimeout(() => view.emit('CharCreatorLoad'), 1000);
    });

    view.on('open_character_creator', () => {
        camPos = util.PositionInFront({ x: playerPos.x -0.18, y: playerPos.y, z: playerPos.z + 1.62 }, alt.Player.local.rot, -0.65);
        camera.Pos = camPos;
        game.pointCamAtCoord(camera.Handle, camPos.x, camPos.y, camPos.z);
    });

    view.on('setGender', (gender: any) => {
        let modelName = gender == 1 ? 'mp_f_freemode_01' : 'mp_m_freemode_01';
        if (alt.Player.local.model != alt.hash(modelName))
            alt.setModel(modelName);
        //game.setEntityCoords(alt.Player.local.scriptID, playerPos.x, playerPos.y, playerPos.z, false, false, false, false);
       // game.setEntityHeading(alt.Player.local.scriptID, 180);

        if (gender == 0)
            game.setPedHeadBlendData(alt.Player.local.scriptID, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
        else
            game.setPedHeadBlendData(alt.Player.local.scriptID, 21, 0, 0, 0, 0, 0, 0, 0, 0, false);
    });

    view.on('setComponentVariation', (type: number, index: number) => {
        game.setPedComponentVariation(alt.Player.local.scriptID, type, index, 0, 0);
    })

    view.on('saveCharacter', (first: string/*, second: string*/) => {
        view.destroy();
        game.doScreenFadeOut(0);
        game.displayHud(true);
        game.displayRadar(true);
        alt.showCursor(false);
        game.freezeEntityPosition(alt.Player.local.scriptID, false);
        alt.toggleGameControls(true);
        camera.SetActiveCamera(false);
        camera.Destroy();
        alt.log('Sauvegarde du character');
        alt.emitServer('MakePlayer', first/*, second*/);
    });

    view.on('setHairColor', (type: number, index: number) => {
        game.setPedHairColor(alt.Player.local.scriptID, type, index);
    });

    view.on('setEyeColor', (index: number) => {
        game.setPedEyeColor(alt.Player.local.scriptID, index);
    });

    view.on('setHairStyle', (type: number) => {
        game.setPedComponentVariation(alt.Player.local.scriptID, 2, type, 0, 2);
    });

    view.on('setHeadOverlayColor', (type: number, index: number) => {
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, type, 1, index, 0);
    });

    view.on('setFaceFeature', (type: number, index: number) => {
        game.setPedFaceFeature(alt.Player.local.scriptID, type, index);
    });

    view.on('updateHeadOverlay', (type: number, index: string) => {
        var def = JSON.parse(index);
        game.setPedHeadOverlay(alt.Player.local.scriptID, type, def.Index, def.Opacity);
        game.setPedHeadOverlayColor(alt.Player.local.scriptID, type, 1, def.Color, def.SecondaryColor)
    });

    view.on('setHeadBlend', (type: string) => {
        var p = JSON.parse(type);
        game.setPedHeadBlendData(alt.Player.local.scriptID, p.ShapeFirst, p.ShapeSecond, 0, p.SkinFirst, p.SkinSecond, 0, p.ShapeMix, p.SkinMix, 0, false);
    });

    view.on('onmenuchange', (index: number) => {

    })

    game.doScreenFadeIn(0);
}