import * as alt from 'alt-client';
import * as game from 'natives';

export function GetDirectionFromRotation(rotation: Vector3): Vector3 {
    var z = rotation.z * (Math.PI / 180.0);
    var x = rotation.x * (Math.PI / 180.0);
    var num = Math.abs(Math.cos(x));

    return new alt.Vector3(
        (-Math.sin(z) * num),
        (Math.cos(z) * num),
        Math.sin(x)
    );
}

export function ForwardVectorFromRotation(rotation: Vector3) {
    let z = rotation.z * (Math.PI / 180.0);
    let x = rotation.x * (Math.PI / 180.0);
    let num = Math.abs(Math.cos(x));
    return new alt.Vector3(-Math.sin(z) * num, Math.cos(z) * num, Math.sin(x));
}

export function PositionInFront(position: Vector3, rotation: Vector3, distance: number) {
    let forwardVector = ForwardVectorFromRotation(rotation);
    let scaledForwardVector = new alt.Vector3(forwardVector.x * distance, forwardVector.y * distance, forwardVector.z * distance);
    return new alt.Vector3(position.x + scaledForwardVector.x, position.y + scaledForwardVector.y, position.z + scaledForwardVector.z);
}

export function LoadModelAsync(model) {
    return new Promise((resolve, reject) => {
        if (typeof model === 'string') {
            model = game.getHashKey(model);
        }

        if (!game.isModelValid(model))
            return resolve(false);

        if (game.hasModelLoaded(model))
            return resolve(true);

        game.requestModel(model);

        let interval = alt.setInterval(() => {
            if (game.hasModelLoaded(model)) {
                alt.clearInterval(interval);
                return resolve(true);
            }
        }, 0);
    });
}

export async function LoadMovement(dict) {
    return new Promise(resolve => {
        game.requestAnimSet(dict);

        let inter = alt.setInterval(() => {
            if (game.hasAnimSetLoaded(dict)) {
                resolve(true);
                alt.clearInterval(inter);
                return;
            }
        }, 5);
    });
}


export function Distance(positionOne, positionTwo) {
    return Math.sqrt(Math.pow(positionOne.x - positionTwo.x, 2) + Math.pow(positionOne.y - positionTwo.y, 2) + Math.pow(positionOne.z - positionTwo.z, 2));
}

export function GetCameraDirection() {
    const heading = game.getGameplayCamRelativeHeading() + game.getEntityHeading(alt.Player.local.scriptID);
    const pitch = game.getGameplayCamRot(0).x;
    var x = -Math.sin(heading * Math.PI / 180.0);
    var y = Math.cos(heading * Math.PI / 180.0);
    var z = Math.sin(pitch * Math.PI / 180.0);

    return new alt.Vector3(x, y, z);
}