using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace GohanForms.Tiles;

public class ZStone : ModItem
{
	public override void SetStaticDefaults()
	{
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[((ModItem)this).Type] = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.createTile = ModContent.TileType<ZSword_Stone>();
		((ModItem)this).Item.useTurn = true;
		((ModItem)this).Item.autoReuse = true;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.useTime = 10;
		((ModItem)this).Item.useAnimation = 15;
		((ModItem)this).Item.maxStack = 99;
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.value = 150;
	}
}
