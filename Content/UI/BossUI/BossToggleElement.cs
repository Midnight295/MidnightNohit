using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace MidnightNohit.Content.UI.BossUI
{
    public class BossToggleElement
    {
        public Texture2D Texture
        {
            get;
            private set;
        }

        public Texture2D GlowTexture
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public FieldInfo DownedBoolean
        {
            get;
            private set;
        }

        public float Weight
        {
            get;
            private set;
        }

        public float Scale
        {
            get;
            private set;
        }

        // Type is used to judge whether or not an element should be visible dependent on which filter is enabled in the Boss List.
        // Type 1 => Terraria
        // Type 2 => Fargo's Soul Mod
        // Type 3 => Calamity
        public int Type
        {
            get;
            private set;
        }

        public BossToggleElement(string texturePath, string nameSingular, FieldInfo downedBoolean, float weight, int type = 1, float scale = 1f)
        {
            if (texturePath.Contains("Images/NPC_Head_Boss_"))
                Texture = Main.Assets.Request<Texture2D>(texturePath, AssetRequestMode.ImmediateLoad).Value;
            else
                Texture = ModContent.Request<Texture2D>(texturePath, AssetRequestMode.ImmediateLoad).Value;

            Name = nameSingular;
            DownedBoolean = downedBoolean;
            Weight = weight;
            Scale = scale;
            Type = type;
        }

        public BossToggleElement Register()
        {
            BossTogglesUIManager.AddBossElement(this);
            return this;
        }

        public bool GetStatus() => (bool)DownedBoolean.GetValue(null);

        public void MarkAsStatus(bool status) => DownedBoolean.SetValue(null, status);

        public void ToggleValue() => DownedBoolean.SetValue(null, !GetStatus());
    }
}
