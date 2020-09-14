using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FiveZ.Entities.Survivors
{
    public class ColorOverlay
    {
        public int color1 { get; set; }
        public int opacity { get; set; }
        public int color2 { get; set; }
        public int id { get; set; }
        public int value { get; set; }
    }

    public class HairOverlay
    {
        public string collection { get; set; }
        public string overlay { get; set; }
    }

    public class OpacityOverlay
    {
        public int id { get; set; }
        public int opacity { get; set; }
        public int value { get; set; }
    }

    public class PlayerCustomization
    {
        public List<ColorOverlay> colorOverlays { get; set; }
        public int eyebrows { get; set; }
        public int eyes { get; set; }
        public int eyebrowsColor1 { get; set; }
        public int eyebrowsOpacity { get; set; }
        public double faceMix { get; set; }
        public int facialHairOpacity { get; set; }
        public int faceFather { get; set; }
        public int faceMother { get; set; }
        public int facialHair { get; set; }
        public int facialHairColor1 { get; set; }
        public int hair { get; set; }
        public int hairColor1 { get; set; }
        public int hairColor2 { get; set; }
        public HairOverlay hairOverlay { get; set; }
        public List<OpacityOverlay> opacityOverlays { get; set; }
        public int sex { get; set; }
        public int skinFather { get; set; }
        public double skinMix { get; set; }
        public int skinMother { get; set; }
        public List<int> structure { get; set; }

        public void ApplyCharacter(IPlayer player)
        {
            lock (player)
            {
                if (!player.Exists)
                    return;

                player.Emit("character:Sync", JsonConvert.SerializeObject(this));
            }
        }
        /*
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
        }*/
    }
}
