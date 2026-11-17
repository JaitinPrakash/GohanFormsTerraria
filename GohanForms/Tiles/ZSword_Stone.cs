using System;
using GohanForms.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ID.TileID;

namespace GohanForms.Tiles;

public class ZSword_Stone : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[((ModBlockType)this).Type] = true;
		Main.tileNoAttach[((ModBlockType)this).Type] = true;
		Main.tileSpelunker[((ModBlockType)this).Type] = true;
		Main.tileLighted[((ModBlockType)this).Type] = true;
		Main.tileLavaDeath[((ModBlockType)this).Type] = false;
		Main.tileWaterDeath[((ModBlockType)this).Type] = false;
		Main.tileObsidianKill[((ModBlockType)this).Type] = false;
		Main.tileTable[((ModBlockType)this).Type] = false;
		Main.tileSolidTop[((ModBlockType)this).Type] = false;
		Sets.DisableSmartCursor[((ModBlockType)this).Type] = true;
		Sets.IgnoredByNpcStepUp[((ModBlockType)this).Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
		TileObjectData.addTile((int)((ModBlockType)this).Type);
		((ModTile)this).RegisterItemDrop(ModContent.ItemType<ZSword>(), Array.Empty<int>());
	}

	public override void NumDust(int x, int y, bool fail, ref int num)
	{
		num = (fail ? 1 : 3);
	}
}
