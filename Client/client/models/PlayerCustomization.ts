import * as alt from 'alt-client';
import * as game from 'natives';

export class HairData {

    public Hair: number;

    public Color: number;

    public HighlightColor: number;

    public constructor(hair: number, color: number, highlightcolor: number) {
        this.Hair = hair;
        this.Color = color;
        this.HighlightColor = highlightcolor;
    }
}

export class HeadBlend {

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

export class HeadOverlay {

    public Index: number;

    public Opacity: number;

    public Color: number = 0;

    public SecondaryColor: number = 0;
}

export enum Sex  {

    Men = 0,
    Female = 1,
}

export interface PlayerCustomInterface {
    Gender: Sex;
    Parents: HeadBlend;
    Features: number[];
    Appearance: HeadOverlay[];
    Decorations: any[];
    Hair: HairData;
    EyeColor: number;

    ApplyCharacter(player: alt.Player): void;
}

export class PlayerCustomization implements PlayerCustomInterface {

    //  Player
    public Gender: Sex;

    //  Parents
    public Parents: HeadBlend;

    //  Features
    public Features: number[] = new Array(20);

    //  Appearance
    public Appearance: HeadOverlay[] = new Array(10);

    //  Tatouages
    public Decorations: any[];

    //  Hair & Colors
    public Hair: HairData;

    public EyeColor: number;

    public constructor(gender: Sex, parents: HeadBlend, features: number[], appearance: HeadOverlay[], decorations: any[], hair: HairData, eyeColor: number) {
        this.Gender = gender;
        this.Parents = parents;
        this.Features = features;
        this.Appearance = appearance;
        this.Decorations = decorations;
        this.Hair = hair;
        this.EyeColor = eyeColor;
    }

    public ApplyCharacter(player: alt.Player) {

        game.setPedHeadBlendData(player.scriptID, this.Parents.ShapeFirst, this.Parents.ShapeSecond, this.Parents.ShapeThird, this.Parents.SkinFirst, this.Parents.SkinSecond, this.Parents.SkinThird, this.Parents.ShapeMix, this.Parents.SkinMix, this.Parents.ThirdMix, false);

        for (let i: number = 0; (i < this.Features.length); i++) {
            game.setPedFaceFeature(player.scriptID, i, this.Features[i]);
        }

        for (let i: number = 0; (i < this.Appearance.length); i++) {
            game.setPedHeadOverlay(player.scriptID, i, this.Appearance[i].Index, this.Appearance[i].Opacity);
            game.setPedHeadOverlayColor(player.scriptID, i, 1, this.Appearance[i].Color, this.Appearance[i].SecondaryColor);
        }
        /*
        for (let decoration: Decoration in this.Decorations) {
            player.SetDecoration(decoration.Collection, decoration.Overlay);
        }
        */
        game.setPedEyeColor(player.scriptID, this.EyeColor);
        game.setPedComponentVariation(player.scriptID, 2, this.Hair.Hair, 0, 0);
        game.setPedHairColor(player.scriptID, this.Hair.Color, this.Hair.HighlightColor);
    }
}