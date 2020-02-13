import * as alt from 'alt-client';
import * as game from 'natives';
import { OpenCharCreator } from 'Creator';

const init = async () => {



    alt.onServer('OpenCreator', () => {
        OpenCharCreator();
    });
};

init();