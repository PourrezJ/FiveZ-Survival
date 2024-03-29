﻿import * as alt from 'alt-client';
import * as native from 'natives';

export interface RaycastResultInterface {
    isHit: boolean;
    pos: alt.Vector3;
    hitEntity: number;
    entityType: number;
    entityHash: number;
}

export class Raycast {
    public static readonly player = alt.Player.local;

    public static raycastRayFromTo(from: alt.Vector3, to: alt.Vector3, ignoreEntity: number, flags: number) {
        let ray = native.startShapeTestRay(
            from.x as number,
            from.y as number,
            from.z as number,
            to.x as number,
            to.y as number,
            to.z as number,
            flags,
            ignoreEntity,
            undefined
        );

        return this.result(ray);
    }

    public static line(scale: number, flags: number, ignoreEntity: number) {
        let playerForwardVector = native.getEntityForwardVector(this.player.scriptID);
        playerForwardVector.x *= scale;
        playerForwardVector.y *= scale;
        playerForwardVector.z *= scale;

        let ray = native.startShapeTestRay(
            this.player.pos.x,
            this.player.pos.y,
            this.player.pos.z,
            this.player.pos.x + playerForwardVector.x,
            this.player.pos.y + playerForwardVector.y,
            this.player.pos.z + playerForwardVector.z,
            flags,
            ignoreEntity,
            undefined
        );

        return this.result(ray);
    }

    public static castCapsule(from: alt.Vector3, to: alt.Vector3, ignoreEntity: number, flags: number, radius: number) {
        const ray = native.startShapeTestCapsule(from.x, from.y, from.z, to.x, to.y, to.z, radius, flags, ignoreEntity, 0);
        return this.result(ray);
    }

    private static result(ray: any): RaycastResultInterface {
        let result = native.getShapeTestResult(ray, undefined, undefined, undefined, undefined);
        let hitEntity = result[4];

        return {
            isHit: result[1],
            pos: new alt.Vector3(result[2].x, result[2].y, result[2].z),
            hitEntity,
            entityType: native.getEntityType(hitEntity),
            entityHash: (native.getEntityType(hitEntity) == 0) ? 0 : native.getEntityModel(hitEntity)
        }
    }
}

export default Raycast;