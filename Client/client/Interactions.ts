import * as alt from 'alt-client';
import * as game from 'natives';
import * as utils from './utils/Util';
import * as ui from './models/UiHelper';
import { Raycast, RaycastResultInterface } from './utils/Raycast';
import * as Globals from './utils/Globals';

let raycastResult: RaycastResultInterface = null;

export function initialize() {
    alt.on('keyup', (key) => {
        if (game.isPauseMenuActive())
            return;

        alt.emitServer('OnKeyUp', key);

        if (key === 82) {
            //ragdoll.stop();
        }
    });

    alt.on("keydown", (key) => {
        if (game.isPauseMenuActive())
            return;

        switch (key) {
            case 88:    // X
            case 69:    // E
            case 85:    // U
            case 87:    // W
            case 113:   // F2
            case 114:   // F3
            case 115:   // F4
            case 116:   // F5
            case 84:    // T
            case 73:    // I
            case 77:    // M
            case 8:     // BackSpace
            case 71:    // G
            case 33:    // PageUP
            case 34:    // PageDown
            case 38:    // ArrowUP
            case 40:    // ArrowDown
            case 96:    // 0
            case 97:    // 1
            case 98:    // 2
            case 99:    // 3    
            case 100:   // 4
            case 101:   // 5
            case 102:   // 6
            case 103:   // 7
            case 104:   // 8
            case 105:   // 9
            case 20:    // Verr Maj
            case 49:    // &
            case 50:    // é
            case 51:    // "

                let vehicle: alt.Vehicle = null;
                let player: alt.Player = null;
                let objNetId = -1;

                if (raycastResult == null)
                    return;
                if (raycastResult.isHit) {
                    /*
                    Streamer.NetworkingEntityClient.EntityList.forEach((item, index) => {
                        if (item == raycastResult.hitEntity) {
                            objNetId = index;
                        }
                    });
                    */
                    //let item = game.getClosestObjectOfType(raycastResult.entityPos.x, raycastResult.entityPos.y, raycastResult.entityPos.z, Globals.MAX_INTERACTION_DISTANCE, raycastResult.hitEntity, false, false, false)

                    raycastResult["entityPos"] = game.getEntityCoords(raycastResult.hitEntity, true);
                    raycastResult["entityHeading"] = game.getEntityHeading(raycastResult.hitEntity);
                }

                if (raycastResult.isHit && raycastResult.entityType == 1 && utils.Distance(alt.Player.local.pos, raycastResult.pos) <= Globals.MAX_INTERACTION_DISTANCE) {
                    player = alt.Player.all.find(p => p.scriptID == raycastResult.hitEntity);
                    alt.emitServer('OnKeyPress', key, JSON.stringify(raycastResult), null, player, objNetId, game.getEntityHeading(raycastResult.hitEntity));
                }
                else if (raycastResult.isHit && raycastResult.entityType == 2 && utils.Distance(alt.Player.local.pos, raycastResult.pos) <= Globals.MAX_INTERACTION_DISTANCE) {
                    vehicle = alt.Vehicle.all.find(v => v.scriptID == raycastResult.hitEntity);
                    alt.emitServer('OnKeyPress', key, JSON.stringify(raycastResult), vehicle, null, objNetId, game.getEntityHeading(raycastResult.hitEntity));
                }
                else if (raycastResult.isHit && raycastResult.entityType == 3 && utils.Distance(alt.Player.local.pos, raycastResult.pos) <= Globals.MAX_INTERACTION_DISTANCE) {
                    alt.emitServer('OnKeyPress', key, JSON.stringify(raycastResult), null, null, objNetId, game.getEntityHeading(raycastResult.hitEntity));
                }
                else {
                    alt.emitServer('OnKeyPress', key, JSON.stringify(raycastResult), null, null, objNetId, game.getEntityHeading(raycastResult.hitEntity));
                }
                break;

            case 82: // R
                //ragdoll.start();
                break;
            case 89:
                break;
        }
    });

    alt.everyTick(() => {
        this.tick++;
        if (this.tick % 20) {
            if (!alt.Player.local.getMeta("IsConnected"))
                return;

            if (!game.hasStreamedTextureDictLoaded("srange_gen"))
                game.requestStreamedTextureDict("srange_gen", true);

            if (game.isEntityDead(alt.Player.local.scriptID, false))
                return;

            if (game.isPedSittingInAnyVehicle(alt.Player.local.scriptID))
                return;

            const _pos = game.getGameplayCamCoord();
            const _dir: alt.Vector3 = utils.GetCameraDirection();

            // Origin is camera position, not player position, so need to set higher values when player has its camera far for character
            const _farAway = new alt.Vector3(
                _pos.x + (_dir.x * 9),
                _pos.y + (_dir.y * 9),
                _pos.z + (_dir.z * 9),
            )

            raycastResult = Raycast.castCapsule(_pos, _farAway, alt.Player.local.scriptID, 255, 1);

            if (raycastResult == null)
                return;

            if (raycastResult.entityHash == 0)
                raycastResult = Raycast.raycastRayFromTo(_pos, _farAway, alt.Player.local.scriptID, 255);

            if (raycastResult == null)
                return;
  
            if (raycastResult.isHit && raycastResult.entityType == 2 && utils.Distance(alt.Player.local.pos, raycastResult.pos) <= Globals.MAX_INTERACTION_DISTANCE) {
                ui.DisplayHelp("Appuyez sur ~INPUT_CONTEXT~ pour intéragir avec le véhicule");
                game.drawSprite("srange_gen", "hits_dot", 0.5, 0.5, 0.005, 0.007, 0, 0, 130, 0, 255, false);
            }
            else if (game.isAnyObjectNearPoint(alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, Globals.MAX_INTERACTION_DISTANCE, true) && game.getClosestObjectOfType(alt.Player.local.pos.x, alt.Player.local.pos.y, alt.Player.local.pos.z, Globals.MAX_INTERACTION_DISTANCE, game.getHashKey("prop_money_bag_01"), false, true, false) != 0) {
                ui.DisplayHelp("Appuyez sur ~INPUT_CONTEXT~ pour ramasser l'objet");
                game.drawSprite("srange_gen", "hits_dot", 0.5, 0.5, 0.005, 0.007, 0, 0, 130, 0, 255, false);
            }
            else
                game.drawSprite("srange_gen", "hits_dot", 0.5, 0.5, 0.005, 0.007, 0, 255, 255, 255, 60, false);
        }
    });
}