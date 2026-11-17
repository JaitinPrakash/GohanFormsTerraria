using DBZGoatLib.Model;
using GohanForms.Assets;
using GohanForms.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace GohanForms.Transformations;

internal class BeastBuff : Transformation
{
	public override AuraData AuraData()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		return new AuraData("DBZMODPORT/Effects/Animations/Aura/BaseAura", 4, BlendState.Additive, new Color(116, 173, 242));
	}

	public override bool CanTransform(Player player)
	{
		GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
		if (!player.HasBuff<BeastBuff>())
		{
			return modPlayer.BeastAchieved;
		}
		return false;
	}

	public override string FormName()
	{
		return "Beast";
	}

	public override string HairTexturePath()
	{
		return "GohanForms/Assets/BeastHair";
	}

	public override Gradient KiBarGradient()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		return new Gradient(new Color(75, 0, 130)).AddStop(1f, new Color(138, 43, 226));
	}

	public override void OnTransform(Player player)
	{
		player.GetModPlayer<GOHPlayer>().BeastActive = true;
	}

	public override void PostTransform(Player player)
	{
		player.GetModPlayer<GOHPlayer>().BeastActive = false;
		player.GetModPlayer<GOHPlayer>().BoostPerc = 0f;
		player.GetModPlayer<GOHPlayer>().BeastCharge = 0;
	}

	public override bool SaiyanSparks()
	{
		return false;
	}

	public override SoundData SoundData()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return new SoundData("DBZMODPORT/Sounds/Awakening", "DBZMODPORT/Sounds/SSG", 260);
	}

	public override bool Stackable()
	{
		return false;
	}

	public override Color TextColor()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Color.Indigo;
	}

	public override void SetStaticDefaults()
	{
		base.kiDrainRate = 5f;
		base.kiDrainRateWithMastery = 2.7f;
		base.attackDrainMulti = 1f;
		if (!BalanceConfigServer.Instance.SSJTweaks)
		{
			base.baseDefenceBonus = 49;
			base.speedMulti = 5f;
		}
		else
		{
			// Extreme Scaling: 295x -> ~320x (BoostPerc mechanic preserved); defense 4500 (hand-set)
			base.baseDefenceBonus = 4500;
			base.speedMulti = 1.4f;
		}
		((Transformation)this).SetStaticDefaults();
	}

	public override void Update(Player player, ref int buffIndex)
	{
		GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
		if (!BalanceConfigServer.Instance.SSJTweaks)
		{
			base.damageMulti = 4.6f + 0.4f * modPlayer.BoostPerc;
		}
		else
		{
			// Extreme Scaling: base 295x, peak ~320x at BoostPerc 1.0 (295 x 1.085 ~= 320)
			base.damageMulti = 295.0f + 25.0f * modPlayer.BoostPerc;
		}
		((Transformation)this).Update(player, ref buffIndex);
	}
}
