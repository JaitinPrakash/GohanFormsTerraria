using GohanForms.Assets;
using Terraria;
using Terraria.ModLoader;

namespace GohanForms.Transformations;

public class EDBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[((ModBuff)this).Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		ref StatModifier damage = ref player.GetDamage(DamageClass.Generic);
		damage += 0.25f;
		ref StatModifier damage2 = ref player.GetDamage(DamageClass.Generic);
		damage2 *= 1.12f;
		player.GetDamage(DamageClass.Generic).Base += 4f;
		player.GetDamage(DamageClass.Generic).Flat += 5f;
		player.moveSpeed -= 0.4f;
		player.statDefense += 5;
		int num = player.FindBuffIndex(ModContent.BuffType<EDBuff>());
		if (num < 45 && player.buffTime[num] <= 5)
		{
			GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
			player.AddBuff(ModContent.BuffType<MysticBuff>(), 600, true, false);
			modPlayer.MysticAchieved = true;
		}
	}
}
