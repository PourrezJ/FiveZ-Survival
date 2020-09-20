import * as alt from 'alt-client';
import * as game from 'natives';
import { Ped } from './models/Ped';

export class Zed extends Ped
{
    constructor(id: number, model: number, position: alt.Vector3, heading: number) {

        super(id, model, position, heading);
        /*
        this.RemoteID = id;
        this.Model = model;
        this.Position = position;
        this.Heading = heading;

        const x: number = position.x;
        const y: number = position.y;
        const z: number = position.z;

        alt.loadModel(this.Model);
        game.requestModel(this.Model);
        this.Handle = game.createPed(26, this.Model, x, y, z, heading, false, true);*/
    }
}
