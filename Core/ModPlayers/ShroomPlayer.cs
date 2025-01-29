using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod;
using CalamityMod.World;
using Terraria.ID;
using CalamityMod.Graphics.Renderers.CalamityRenderers;
using CalamityMod.Particles;

namespace MidnightNohit.Core.ModPlayers
{
    public class ShroomPlayer : ModPlayer
    {
        public bool trippy = false;
        public int trippyLevel = 1;

        public override void ResetEffects()
        {
            trippy = false;
            trippyLevel = 1;
        }

        public override void UpdateDead()
        {
            trippy = false;
            trippyLevel = 1;
        }

        //All of Calamity's shroom rendering code. None of it is made by me and all credit goes to the original creators of this code.
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (trippy)
            {
                if (Main.myPlayer == Player.whoAmI)
                {
                    Rectangle screenArea = new Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 50, Main.screenWidth + 1000, Main.screenHeight + 100);
                    int dustDrawn = 0;
                    float maxShroomDust = Main.maxDustToDraw / 2;
                    Color shroomColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Main.DiscoR);
                    for (int i = 0; i < Main.maxDustToDraw; i++)
                    {
                        Dust dust = Main.dust[i];
                        if (dust.active)
                        {
                            // Only draw dust near the screen, for performance reasons.
                            if (new Rectangle((int)dust.position.X, (int)dust.position.Y, 4, 4).Intersects(screenArea))
                            {
                                dust.color = shroomColor;
                                for (int j = 0; j < 4; j++)
                                {
                                    Vector2 dustDrawPosition = dust.position;
                                    Vector2 dustCenter = dustDrawPosition + new Vector2(4f);

                                    float distanceX = Math.Abs(dustCenter.X - Player.Center.X);
                                    float distanceY = Math.Abs(dustCenter.Y - Player.Center.Y);
                                    if (j == 0 || j == 2)
                                        dustDrawPosition.X = Player.Center.X + distanceX;
                                    else
                                        dustDrawPosition.X = Player.Center.X - distanceX;

                                    dustDrawPosition.X -= 4f;

                                    if (j == 0 || j == 1)
                                        dustDrawPosition.Y = Player.Center.Y + distanceY;
                                    else
                                        dustDrawPosition.Y = Player.Center.Y - distanceY;

                                    dustDrawPosition.Y -= 4f;
                                    Main.spriteBatch.Draw(TextureAssets.Dust.Value, dustDrawPosition - Main.screenPosition, dust.frame, dust.color, dust.rotation, new Vector2(4f), dust.scale, SpriteEffects.None, 0f);
                                    dustDrawn++;
                                }

                                // Break if too many dust clones have been drawn
                                if (dustDrawn > maxShroomDust)
                                    break;
                            }
                        }
                    }
                }
            }
            else // This is such a stupid way to reset this but you can't just put it in ResetEffects
            {
                trippyLevel = 1;
            }
        }
    }

    public class ShroomGlobalProjectile : GlobalProjectile
    {
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippy)
                return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Main.DiscoR);
            return null;
        }

        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippy)
            {
                Texture2D texture = TextureAssets.Projectile[projectile.type].Value;

                SpriteEffects spriteEffects = SpriteEffects.None;
                if (projectile.spriteDirection == -1)
                    spriteEffects = SpriteEffects.FlipHorizontally;

                Color rainbow = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Main.DiscoR);
                Color alphaColor = projectile.GetAlpha(rainbow);
                float RGBMult = 0.99f;
                alphaColor.R = (byte)(alphaColor.R * RGBMult);
                alphaColor.G = (byte)(alphaColor.G * RGBMult);
                alphaColor.B = (byte)(alphaColor.B * RGBMult);
                alphaColor.A = (byte)(alphaColor.A * RGBMult);
                int totalAfterimages = Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 3 ? 16 : (Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 2 ? 12 : 4);
                for (int i = 0; i < totalAfterimages; i++)
                {
                    Vector2 position = projectile.position;
                    float distanceFromTargetX = Math.Abs(projectile.Center.X - Main.player[Main.myPlayer].Center.X);
                    float distanceFromTargetY = Math.Abs(projectile.Center.Y - Main.player[Main.myPlayer].Center.Y);

                    float smallDistanceMult = 0.48f;
                    float largeDistanceMult = 1.33f;
                    bool whatTheFuck = Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 3;

                    switch (i)
                    {
                        case 0:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY;
                            break;

                        case 1:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY;
                            break;

                        case 2:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY;
                            break;

                        case 3:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY;
                            break;

                        case 4: // 1 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 1f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0f : largeDistanceMult));
                            break;

                        case 5: // 4 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 1f : smallDistanceMult));
                            break;

                        case 6: // 7 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 1f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0f : largeDistanceMult));
                            break;

                        case 7: // 10 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 1f : smallDistanceMult));
                            break;

                        case 8: // 11 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0.5f : largeDistanceMult));
                            break;

                        case 9: // 2 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0.5f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0f : smallDistanceMult));
                            break;

                        case 10: // 5 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0.5f : largeDistanceMult));
                            break;

                        case 11: // 8 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0.5f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0f : smallDistanceMult));
                            break;

                        case 12:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY * 0.5f;
                            break;

                        case 13:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY * 0.5f;
                            break;

                        case 14:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY * 0.5f;
                            break;

                        case 15:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY * 0.5f;
                            break;

                        default:
                            break;
                    }

                    position.X -= projectile.width / 2;
                    position.Y -= projectile.height / 2;

                    int frameHeight = texture.Height / Main.projFrames[projectile.type];
                    int currentframeHeight = frameHeight * projectile.frame;
                    Rectangle frame = new Rectangle(0, currentframeHeight, texture.Width, frameHeight);

                    Vector2 halfSize = frame.Size() / 2;

                    Main.spriteBatch.Draw(texture,
                        new Vector2(position.X - Main.screenPosition.X + (float)(projectile.width / 2) - (float)TextureAssets.Projectile[projectile.type].Width() * projectile.scale / 2f + halfSize.X * projectile.scale,
                        position.Y - Main.screenPosition.Y + (float)projectile.height - (float)TextureAssets.Projectile[projectile.type].Height() * projectile.scale / (float)Main.projFrames[projectile.type] + 4f + halfSize.Y * projectile.scale + projectile.gfxOffY),
                        frame, alphaColor, projectile.rotation, halfSize, projectile.scale, spriteEffects, 0f);
                }
            }
            return true;
        }
    }

    public partial class ShroomGlobalNPC : GlobalNPC
    {
        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            if (Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippy)
                return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Main.DiscoR);
            return null;
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (Main.LocalPlayer.GetModPlayer<ShroomPlayer>().trippy && !npc.IsABestiaryIconDummy)
            {
                SpriteEffects spriteEffects = SpriteEffects.None;
                if (npc.spriteDirection == 1)
                    spriteEffects = SpriteEffects.FlipHorizontally;

                Color rainbow = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Main.DiscoR);
                Color alphaColor = npc.GetAlpha(rainbow);
                float RGBMult = 0.99f;
                alphaColor.R = (byte)(alphaColor.R * RGBMult);
                alphaColor.G = (byte)(alphaColor.G * RGBMult);
                alphaColor.B = (byte)(alphaColor.B * RGBMult);
                alphaColor.A = (byte)(alphaColor.A * RGBMult);
                int totalAfterimages = Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 3 ? 16 : (Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 2 ? 12 : 4);
                for (int i = 0; i < totalAfterimages; i++)
                {
                    Vector2 position = npc.position;
                    float distanceFromTargetX = Math.Abs(npc.Center.X - Main.player[Main.myPlayer].Center.X);
                    float distanceFromTargetY = Math.Abs(npc.Center.Y - Main.player[Main.myPlayer].Center.Y);

                    float smallDistanceMult = 0.48f;
                    float largeDistanceMult = 1.33f;
                    bool whatTheFuck = Main.player[Main.myPlayer].GetModPlayer<ShroomPlayer>().trippyLevel == 3;

                    switch (i)
                    {
                        case 0:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY;
                            break;

                        case 1:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY;
                            break;

                        case 2:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY;
                            break;

                        case 3:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY;
                            break;

                        case 4: // 1 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 1f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0f : largeDistanceMult));
                            break;

                        case 5: // 4 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 1f : smallDistanceMult));
                            break;

                        case 6: // 7 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 1f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0f : largeDistanceMult));
                            break;

                        case 7: // 10 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 1f : smallDistanceMult));
                            break;

                        case 8: // 11 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0.5f : largeDistanceMult));
                            break;

                        case 9: // 2 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0.5f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y - (distanceFromTargetY * (whatTheFuck ? 0f : smallDistanceMult));
                            break;

                        case 10: // 5 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X + (distanceFromTargetX * (whatTheFuck ? 0f : smallDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0.5f : largeDistanceMult));
                            break;

                        case 11: // 8 o'clock position
                            position.X = Main.player[Main.myPlayer].Center.X - (distanceFromTargetX * (whatTheFuck ? 0.5f : largeDistanceMult));
                            position.Y = Main.player[Main.myPlayer].Center.Y + (distanceFromTargetY * (whatTheFuck ? 0f : smallDistanceMult));
                            break;

                        case 12:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY * 0.5f;
                            break;

                        case 13:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y - distanceFromTargetY * 0.5f;
                            break;

                        case 14:
                            position.X = Main.player[Main.myPlayer].Center.X + distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY * 0.5f;
                            break;

                        case 15:
                            position.X = Main.player[Main.myPlayer].Center.X - distanceFromTargetX * 0.5f;
                            position.Y = Main.player[Main.myPlayer].Center.Y + distanceFromTargetY * 0.5f;
                            break;


                        default:
                            break;
                    }

                    position.X -= npc.width / 2;
                    position.Y -= npc.height / 2;

                    Vector2 halfSize = npc.frame.Size() / 2;

                    int width = TextureAssets.Npc[npc.type] is null ? 0 : TextureAssets.Npc[npc.type].Width();
                    int height = TextureAssets.Npc[npc.type] is null ? 0 : TextureAssets.Npc[npc.type].Height();
                    spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, new Vector2(position.X - screenPos.X + (float)(npc.width / 2) - (float)width * npc.scale / 2f + halfSize.X * npc.scale, position.Y - screenPos.Y + (float)npc.height - (float)height * npc.scale / (float)Main.npcFrameCount[npc.type] + 4f + halfSize.Y * npc.scale + npc.gfxOffY), npc.frame, alphaColor, npc.rotation, halfSize, npc.scale, spriteEffects, 0f);
                }
                
            }
            /*else
            {
                // VHex and Miracle Blight visuals do not appear if Odd Mushroom is in use for sanity reasons
                if (npc.Calamity().vulnerabilityHex > 0)
                {
                    float compactness = npc.width * 0.6f;
                    if (compactness < 10f)
                        compactness = 10f;
                    float power = npc.height / 100f;
                    if (power > 2.75f)
                        power = 2.75f;
                    if (VulnerabilityHexFireDrawer is null || VulnerabilityHexFireDrawer.LocalTimer >= VulnerabilityHexFireDrawer.SetLifetime)
                        VulnerabilityHexFireDrawer = new FireParticleSet(npc.Calamity().vulnerabilityHex, 1, Color.Red * 1.25f, Color.Red, compactness, power);
                    else
                        VulnerabilityHexFireDrawer.DrawSet(npc.Bottom - Vector2.UnitY * (12f - npc.gfxOffY));
                }
                else
                    VulnerabilityHexFireDrawer = null;

                // Only draw the NPC if told to by the miracle blight drawer.
                if (MiracleBlightRenderer.ValidToDraw(npc))
                    return MiracleBlightRenderer.ActuallyDoPreDraw;
            }*/
            return true;
        }

        [JITWhenModsEnabled(ModCompatability.Calamity.Name)]
        public void BuhWuhBuh(NPC npc)
        {
            if (npc.Calamity().vulnerabilityHex > 0) ;
        }

    }
}
