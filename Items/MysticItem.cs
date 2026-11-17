using GohanForms.Assets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GohanForms.Items;

internal class MysticItem : ModItem
{
	public override void SetStaticDefaults()
	{
	}

	public override void SetDefaults()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.potion = false;
		((Entity)((ModItem)this).Item).width = 40;
		((Entity)((ModItem)this).Item).height = 40;
		((ModItem)this).Item.useTime = 20;
		((ModItem)this).Item.useAnimation = 20;
		((ModItem)this).Item.useStyle = 2;
		((ModItem)this).Item.UseSound = SoundID.Item1;
		((ModItem)this).Item.autoReuse = false;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.scale = 1f;
		((ModItem)this).Item.rare = 7;
	}

	public override bool? UseItem(Player player)
	{
		return !player.GetModPlayer<GOHPlayer>().MysticAchieved;
	}

	public override void OnConsumeItem(Player player)
	{
		GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
		if (!modPlayer.MysticAchieved)
		{
			modPlayer.MysticAchieved = true;
		}
	}
}
