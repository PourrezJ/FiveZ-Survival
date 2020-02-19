import * as alt from 'alt-client';
import * as game from 'natives';
import { Ped } from './models/Ped';

let Entities: Array<any> = new Array<any>();

export class Entity {

    public id: number;
    public type: number;
    public position: alt.Vector3;
    public data: any;
}

export function initialize()
{
    alt.onServer("entitySync:create", (entity: Entity) => {
        alt.log("entitySync:create");
        alt.log(entity.id);
        alt.log(entity.type);
        alt.log(entity.position);

        switch (entity.type) {
            case 0:
                //Marker
                break;

            case 1:
                //Ped
                Entities[entity.id] = new Ped(entity.id, entity.data.Model, entity.position, 0);
                break;
        }
    })

    alt.onServer("entitySync:remove", (entityId: number) => {
        const entity = Entities[entityId];

        switch (entity.type) {
            case 0:
                //Marker
                break;

            case 1:
                //Ped
                break;
        }
    })

    alt.onServer("entitySync:updatePosition", (entityId: number, position: alt.Vector3) => {
        const entity = Entities[entityId];

        switch (entity.type) {
            case 0:
                //Marker
                break;

            case 1:
                //Ped
                break;
        }
    })

    alt.onServer("entitySync:updateData", (entityId: number, newEntityData: any) => {
        const entity = Entities[entityId];

        if (entity == null)
            return;

        let entityData = entity.data;

        if (!entityData) {
            entityData = {};
        }
        for (const key in newEntityData) {
            entityData[key] = newEntityData[key];
        }
    })

    alt.onServer("entitySync:clearCache", (entityId: number) => {
        delete Entities[entityId];
    })
}

export function onTick() {
    for (const entity in Entities)
    {
        
    }
}