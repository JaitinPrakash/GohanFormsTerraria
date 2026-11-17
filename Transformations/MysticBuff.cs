using DBZGoatLib;
using DBZGoatLib.Model;
using GohanForms.Assets;
using GohanForms.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace GohanForms.Transformations;

public class MysticBuff : Transformation
{
	public override AuraData AuraData()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		return new AuraData("DBZModPort/Effects/Animations/Aura/BaseAura", 4, BlendState.Additive, new Color(175, 175, 180));
	}

	public override bool CanTransform(Player player)
	{
		GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
		if (!player.HasBuff<MysticBuff>())
		{
			return modPlayer.MysticAchieved;
		}
		return false;
	}

	public override string FormName()
	{
		return "Ultimate";
	}

	public override string HairTexturePath()
	{
		return string.Empty;
	}

	public override Gradient KiBarGradient()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		return new Gradient(new Color(152, 152, 152)).AddStop(1f, new Color(216, 216, 216));
	}

	public override void OnTransform(Player player)
	{
		player.GetModPlayer<GOHPlayer>().CD = true;
		player.GetModPlayer<GOHPlayer>().MysticActive = true;
	}

	public override void PostTransform(Player player)
	{
		player.GetModPlayer<GOHPlayer>().MysticActive = false;
	}

	public override bool SaiyanSparks()
	{
		return true;
	}

	public override SoundData SoundData()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);
	}

	public override bool Stackable()
	{
		return false;
	}

	public override Color TextColor()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Color.WhiteSmoke;
	}

	public override void SetStaticDefaults()
	{
		base.kiDrainRate = 4f;
		base.kiDrainRateWithMastery = 2f;
		base.attackDrainMulti = 0.55f;
		if (!BalanceConfigServer.Instance.SSJTweaks)
		{
			base.baseDefenceBonus = 19;
			base.damageMulti = 3.5f;
			base.speedMulti = 3.25f;
		}
		else
		{
			// Extreme Scaling: 60x (= SSJ God / full-evil SSJ3FP); defense 19 x 60 = 1140
			base.baseDefenceBonus = 1140;
			base.damageMulti = 60.0f;
			base.speedMulti = 1.12f;
		}
		base.SetStaticDefaults();
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<GOHPlayer>().CD = false;
		if (player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<MysticBuff>()) <= 1f)
		{
			player.GetModPlayer<GPlayer>().MasteryMultiplier = 3f;
		}
		base.Update(player, ref buffIndex);
		base.SetStaticDefaults();
	}
}
