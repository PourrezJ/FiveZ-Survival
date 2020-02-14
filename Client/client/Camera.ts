import * as alt from 'alt-client';
import * as game from 'natives';

enum CameraMoveType {
    Up,
    Down,
}

export class Camera {
    Handle: number;
    Fov: number;

    get Pos(): Vector3 {
        return game.getCamCoord(this.Handle);
    }
    set Pos(pos: Vector3) {
        game.setCamCoord(this.Handle, pos.x, pos.y, pos.z);
    }

    get Rot(): Vector3 {
        return game.getCamRot(this.Handle, 0);
    }
    set Rot(rot: Vector3) {
        game.setCamRot(this.Handle, rot.x, rot.y, rot.z, 0);
    }


    constructor(pos: Vector3, rot: Vector3, fov: number = 50) {
        this.Pos = pos;
        this.Rot = rot;
        this.Fov = fov;
        this.Handle = game.createCameraWithParams(game.getHashKey("DEFAULT_SCRIPTED_CAMERA"), pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, this.Fov, true, 2);
    }

    SetActiveCamera(active: boolean) {
        game.setCamActive(this.Handle, active);
        game.renderScriptCams(active, false, 0, true, false, 0)
        if (active)
            game.setFocusPosAndVel(this.Pos.x, this.Pos.y, this.Pos.z, 100, 100, 1000);
        else
            game.clearFocus();
    }
    Destroy() {
        this.SetActiveCamera(false);
        game.destroyCam(this.Handle, true);
    }

    MoveToAir(moveTo: CameraMoveType, switchType: number, delay: number = 10000) {
        switch (moveTo) {
            case CameraMoveType.Up:
                game.displayHud(false);
                game.displayRadar(false);
                game.switchOutPlayer(game.playerId(), 0, switchType)
                break;
            case CameraMoveType.Down:
                break;
        }
    }

}