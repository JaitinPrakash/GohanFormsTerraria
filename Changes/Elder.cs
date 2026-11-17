using System.Collections.Generic;
using DBZGoatLib;
using GohanForms.Assets;
using GohanForms.Transformations;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.NPCID;
using static Terraria.ID.NPCID.Sets;

namespace GohanForms.Changes;

[AutoloadHead]
public class Elder : ModNPC
{
	public override void SetStaticDefaults()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		Sets.MPAllowedEnemies[((ModNPC)this).Type] = true;
		Sets.ShimmerTownTransform[((ModNPC)this).Type] = false;
		NPCHappiness val = ((ModNPC)this).NPC.Happiness;
		val = val.SetBiomeAffection<HallowBiome>((AffectionLevel)50);
		val = val.SetBiomeAffection<DesertBiome>((AffectionLevel)(-50));
		val = val.SetNPCAffection(18, (AffectionLevel)50);
		val.SetNPCAffection(441, (AffectionLevel)(-50));
		NPCBestiaryDrawModifiers val2 = new NPCBestiaryDrawModifiers();
		val2.Velocity = 1f;
		NPCBestiaryDrawModifiers value = val2;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).NPC.type, value);
	}

	public override void SetDefaults()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.townNPC = true;
		((ModNPC)this).NPC.friendly = true;
		((Entity)((ModNPC)this).NPC).width = 20;
		((Entity)((ModNPC)this).NPC).height = 20;
		((ModNPC)this).NPC.aiStyle = 7;
		((ModNPC)this).NPC.defense = 35;
		((ModNPC)this).NPC.lifeMax = 300;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.DeathSound = SoundID.NPCDeath1;
		((ModNPC)this).NPC.knockBackResist = 0.5f;
		Main.npcFrameCount[((ModNPC)this).NPC.type] = 25;
		Sets.ExtraFramesCount[((ModNPC)this).NPC.type] = 0;
		Sets.AttackFrameCount[((ModNPC)this).NPC.type] = 1;
		Sets.DangerDetectRange[((ModNPC)this).NPC.type] = 500;
		Sets.AttackType[((ModNPC)this).NPC.type] = 1;
		Sets.AttackTime[((ModNPC)this).NPC.type] = 30;
		Sets.AttackAverageChance[((ModNPC)this).NPC.type] = 10;
		Sets.HatOffsetY[((ModNPC)this).NPC.type] = 4;
		((ModNPC)this).AnimationType = 22;
	}

	public override bool CanTownNPCSpawn(int numTownNPCs)
	{
		return CanKaiSpawn.SwordBroke;
	}

	public override List<string> SetNPCNameList()
	{
		return new List<string> { "Kai" };
	}

	public override void SetChatButtons(ref string button, ref string button2)
	{
		button = "Potential Unleash";
	}

	public override void OnChatButtonClicked(bool firstButton, ref string shopName)
	{
		if (firstButton)
		{
			Player val = Main.player[Main.myPlayer];
			ModLoader.GetMod("GohanForms");
			if (!val.GetModPlayer<GOHPlayer>().MysticAchieved)
			{
				Main.NewText("You have ritual buff, after 4 minutes your potential will be unleashed", byte.MaxValue, byte.MaxValue, byte.MaxValue);
				val.AddBuff(ModContent.BuffType<EDBuff>(), 14400, true, false);
			}
			else
			{
				Main.NewText("You have already reached your maximum", byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			if (val.GetModPlayer<GPlayer>().Trait == "Legendary")
			{
				Main.NewText("Gifted warriors like you dont need such a form", byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}
	}

	public override string GetChat()
	{
		NPC.FindFirstNPC(ModContent.NPCType<Elder>());
		return Main.rand.Next(2) switch
		{
			0 => "Don't ask me how I ended up in this sword", 
			1 => "Don't you have any magazines with you?", 
			_ => "Do you want me to unleash your potential?", 
		};
	}

	public override void TownNPCAttackStrength(ref int damage, ref float knockback)
	{
		damage = 15;
		knockback = 2f;
	}

	public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
	{
		cooldown = 5;
		randExtraCooldown = 10;
	}

	public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
	{
		projType = 95;
		attackDelay = 1;
	}

	public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
	{
		multiplier = 7f;
	}
}
