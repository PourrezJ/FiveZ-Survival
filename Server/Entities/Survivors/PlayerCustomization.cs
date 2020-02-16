using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FiveZ.Entities.Survivors
{
    public class HairData
    {
        public int Hair;
        public int Color;
        public int HighlightColor;

        public HairData(byte hair, byte color, byte highlightcolor)
        {
            Hair = hair;
            Color = color;
            HighlightColor = highlightcolor;
        }
    }

    public class HeadBlend
    {
        public int ShapeFirst;
        public int ShapeSecond;
        public int ShapeThird;
        public int SkinFirst;
        public int SkinSecond;
        public int SkinThird;

        public float ShapeMix;
        public float SkinMix;
        public float ThirdMix;
    }

    public class HeadOverlay
    {
        public int Index;
        public float Opacity;
        public int Color = 0;
        public int SecondaryColor = 0;
    }

    public enum Sex : int
    {
        Men = 0,
        Female = 1
    }

    public class PlayerCustomization
    {
        // Player
        public Sex Gender;

        // Parents
        public HeadBlend Parents;

        // Features
        public float[] Features = new float[20];

        // Appearance
        public HeadOverlay[] Appearance = new HeadOverlay[10];

        // Tatouages
        public List<Decoration> Decorations = new List<Decoration>();

        // Hair & Colors
        public HairData Hair;

        public int EyeColor;

        public PlayerCustomization()
        {
            Gender = 0;
            Parents = new HeadBlend();

            for (int i = 0; i < Features.Length; i++)
                Features[i] = 0;
            for (int i = 0; i < Appearance.Length; i++)
                Appearance[i] = new HeadOverlay();

            Hair = new HairData(0, 0, 0);
        }

        public void ApplyCharacter(IPlayer player)
        {
            lock (player)
            {
                if (!player.Exists)
                    return;

                player.Emit("ApplyCharacter", JsonConvert.SerializeObject(this));
            }
        }

        public bool HasDecoration(uint overlay)
        {
            if (Decorations == null)
                return false;

            foreach (Decoration decoration in Decorations)
            {
                if (decoration.Overlay == overlay)
                    return true;
            }

            return false;
        }
    }
}
