import * as alt from 'alt-client';
import * as game from 'natives';
import * as util from '../utils/Util'

export class Ped {
    public Handle: number;
    public RemoteID: number;
    public Model: number;
    public Position: alt.Vector3;
    public Heading: number;

    constructor(id: number, model: number, position: alt.Vector3, heading: number) {
        this.RemoteID = id;
        this.Model = model;
        this.Position = position;
        this.Heading = heading;

        const x: number = position.x;
        const y: number = position.y;
        const z: number = position.z;

        alt.loadModel(this.Model);
        game.requestModel(this.Model);
        this.Handle = game.createPed(26, this.Model, x, y, z, heading, false, true);
    }

    public Freeze(status: boolean) {
        game.taskSetBlockingOfNonTemporaryEvents(this.Handle, true);
        game.setEntityInvincible(this.Handle, true);
        game.freezeEntityPosition(this.Handle, true);
    }

    public TaskGoTo(position: alt.Vector3, speed: number = 1, timeout: number = 10000) {
        game.taskGoStraightToCoord(this.Handle, position.x as number, position.y as number, position.z as number, speed, timeout, 0.0, 0.0);
    }
}