using System;
using GohanForms.Transformations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace GohanForms.Assets;

public class Lightning : PlayerDrawLayer
{
	public override Position GetDefaultPosition()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		return (Position)new AfterParent(PlayerDrawLayers.Torso);
	}

	public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
	{
		return true;
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode != 2)
		{
			_ = GohanForms.Instance;
			if (drawInfo.shadow == 0f && drawInfo.drawPlayer.HasBuff<BeastBuff>())
			{
				drawInfo.DrawDataCache.Add(LightningEffectDrawData(drawInfo.drawPlayer, drawInfo.Position, "GohanForms/Assets/LightningPurple"));
			}
		}
	}

	public static DrawData LightningEffectDrawData(Player drawPlayer, Vector2 position, string lightningTexture)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		_ = GohanForms.Instance;
		int num = drawPlayer.GetModPlayer<GOHPlayer>().lightningFrameTimer / 5;
		Texture2D val = (Texture2D)ModContent.Request<Texture2D>(lightningTexture, (AssetRequestMode)2);
		int num2 = val.Height / 3;
		int num3 = (int)(position.X + (float)((Entity)drawPlayer).width / 2f - Main.screenPosition.X);
		int num4 = (int)(position.Y + (float)((Entity)drawPlayer).height / 0.6f - Main.screenPosition.Y);
		return new DrawData(val, new Vector2((float)num3, (float)num4), (Rectangle?)new Rectangle(0, num2 * num, val.Width, num2), Color.White, 0f, new Vector2((float)val.Width / 2f, (float)val.Height / 2f), 1f, (SpriteEffects)0, 0f);
	}

	public static DrawData LightningEffect(Player drawPlayer, Vector2 position, string lightningTexture)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		_ = GohanForms.Instance;
		GOHPlayer modPlayer = drawPlayer.GetModPlayer<GOHPlayer>();
		Texture2D val = (Texture2D)ModContent.Request<Texture2D>(lightningTexture, (AssetRequestMode)2);
		int num = val.Height / modPlayer.lightning3FrameCount;
		int num2 = (int)(position.X + (float)((Entity)drawPlayer).width / 2f - Main.screenPosition.X);
		int num3 = (int)(position.Y + (float)((Entity)drawPlayer).height / 0.6f - Main.screenPosition.Y);
		return new DrawData(val, new Vector2((float)num2, (float)num3), (Rectangle?)new Rectangle(0, num * modPlayer.lightning3FrameIndex, val.Width, num), Color.White, 0f, new Vector2((float)val.Width / 2f, (float)num + (float)((Entity)drawPlayer).height / 2f), 1f, (SpriteEffects)0, 0f);
	}
}
