using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FiveZ.Entities.Survivors
{
    public class ColorOverlay
    {
        [JsonProperty("color1")]
        public int Color1 { get; set; }

        [JsonProperty("opacity")]
        public int Opacity { get; set; }

        [JsonProperty("color2")]
        public int Color2 { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class HairOverlay
    {
        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("overlay")]
        public string Overlay { get; set; }
    }

    public class OpacityOverlay
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("opacity")]
        public int Opacity { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class PlayerCustomization
    {
        [JsonProperty("colorOverlays")]
        public List<ColorOverlay> ColorOverlays { get; set; }

        [JsonProperty("eyebrows")]
        public int Eyebrows { get; set; }

        [JsonProperty("eyes")]
        public int Eyes { get; set; }

        [JsonProperty("eyebrowsColor1")]
        public int EyebrowsColor1 { get; set; }

        [JsonProperty("eyebrowsOpacity")]
        public int EyebrowsOpacity { get; set; }

        [JsonProperty("faceMix")]
        public double FaceMix { get; set; }

        [JsonProperty("facialHairOpacity")]
        public int FacialHairOpacity { get; set; }

        [JsonProperty("faceFather")]
        public int FaceFather { get; set; }

        [JsonProperty("faceMother")]
        public int FaceMother { get; set; }

        [JsonProperty("facialHair")]
        public int FacialHair { get; set; }

        [JsonProperty("facialHairColor1")]
        public int FacialHairColor1 { get; set; }

        [JsonProperty("hair")]
        public int Hair { get; set; }

        [JsonProperty("hairColor1")]
        public int HairColor1 { get; set; }

        [JsonProperty("hairColor2")]
        public int HairColor2 { get; set; }

        [JsonProperty("hairOverlay")]
        public HairOverlay HairOverlay { get; set; }

        [JsonProperty("opacityOverlays")]
        public List<OpacityOverlay> OpacityOverlays { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }

        [JsonProperty("skinFather")]
        public int SkinFather { get; set; }

        [JsonProperty("skinMix")]
        public double SkinMix { get; set; }

        [JsonProperty("skinMother")]
        public int SkinMother { get; set; }

        [JsonProperty("structure")]
        public List<int> Structure { get; set; }

        public void ApplyCharacter(IPlayer player)
        {
            lock (player)
            {
                if (!player.Exists)
                    return;

                player.Model = (uint)(Sex == 0 ? AltV.Net.Enums.PedModel.FreemodeMale01 : AltV.Net.Enums.PedModel.FreemodeFemale01);

                player.EmitLocked("character:Sync", JsonConvert.SerializeObject(this));
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
