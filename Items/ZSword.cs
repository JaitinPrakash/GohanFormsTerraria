using System;
using GohanForms.Assets;
using GohanForms.Changes;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace GohanForms.Items;

public class ZSword : ModItem
{
	private SoundStyle sound = new SoundStyle("GohanForms/Assets/SwordBreaks", (SoundType)0);

	public override void SetStaticDefaults()
	{
	}

	public override void SetDefaults()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.damage = 81;
		((ModItem)this).Item.DamageType = DamageClass.Melee;
		((Entity)((ModItem)this).Item).width = 40;
		((Entity)((ModItem)this).Item).height = 40;
		((ModItem)this).Item.useTime = 60;
		((ModItem)this).Item.useAnimation = 60;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.knockBack = 6f;
		((ModItem)this).Item.value = 1000;
		((ModItem)this).Item.rare = 6;
		((ModItem)this).Item.UseSound = SoundID.Item1;
		((ModItem)this).Item.autoReuse = false;
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		GOHPlayer modPlayer = player.GetModPlayer<GOHPlayer>();
		target.AddBuff(36, 600, false);
		if ((target.type != 245 && target.type != 246 && target.type != 249 && target.type != 247 && target.type != 248) || CanKaiSpawn.SwordBroke)
		{
			return;
		}
		CanKaiSpawn.SwordBroke = true;
		modPlayer.SwordBroke = true;
		SoundStyle val = sound.WithVolumeScale(4f);
		val = val.WithPitchOffset(0.8f);
		SoundEngine.PlaySound(ref val, (Vector2?)((Entity)player).position, (SoundUpdateCallback)null);
		((ModItem)this).Item.TurnToAir(false);
		IEntitySource val2 = null;
		Main.LocalPlayer.QuickSpawnItem(val2, 1570, 1);
		if (((Entity)player).whoAmI != Main.myPlayer)
		{
			return;
		}
		int num = ModContent.NPCType<Elder>();
		if (Main.netMode != 1)
		{
			if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
			{
				NPC.SpawnOnPlayer(((Entity)player).whoAmI, num);
			}
		}
		else
		{
			NetMessage.SendData(61, -1, -1, (NetworkText)null, ((Entity)player).whoAmI, (float)num, 0f, 0f, 0, 0, 0);
		}
	}

	public override void AddRecipes()
	{
		Recipe val = ((ModItem)this).CreateRecipe(1);
		val.AddIngredient(1225, 20);
		val.AddIngredient(19, 10);
		val.AddIngredient(175, 15);
		val.AddIngredient(549, 5);
		val.AddIngredient(548, 5);
		val.AddIngredient(547, 5);
		val.AddTile(134);
		val.Register();
		Recipe val2 = ((ModItem)this).CreateRecipe(1);
		val2.AddIngredient(1225, 20);
		val2.AddIngredient(706, 10);
		val2.AddIngredient(175, 15);
		val2.AddIngredient(549, 5);
		val2.AddIngredient(548, 5);
		val2.AddIngredient(547, 5);
		val2.AddTile(134);
		val2.Register();
	}

	public ZSword()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
	}
}
