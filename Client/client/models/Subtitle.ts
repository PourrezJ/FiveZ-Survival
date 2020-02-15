import * as game from 'natives';
import * as ui from '../models/UiHelper';

export class Subtitle {
    alpha: number;
    text: string;
    time: number;
    res: any;
    static subtitle: Subtitle;

    constructor(text, time) {
        this.alpha = 255;
        this.text = text;
        this.time = Date.now() + time;
        this.res = game.getActiveScreenResolution(0, 0);
        Subtitle.subtitle = this;
    }

    Draw() {
        if (this.time < Date.now()) {
            this.alpha -= 1;
        }

        if (this.alpha <= 10) {
            Subtitle.subtitle = undefined;
            return;
        }

        ui.DrawText2d(this.text, 0.5, 0.80, 0.8, 4, 255, 255, 255, this.alpha, true);       
    }
}