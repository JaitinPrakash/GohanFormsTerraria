using System;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using DBZGoatLib.Model;
using DBZMODPORT;
using GohanForms.Transformations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace GohanForms.Assets;

internal class GOHPlayer : ModPlayer
{
	public class BSSFPanel : TransformationTree
	{
		public override bool Complete()
		{
			return false;
		}

		public override bool Condition(Player player)
		{
			return true;
		}

		public override Connection[] Connections()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			return new Connection[1]
			{
				new Connection(6f, 0f, 1f, false, new Gradient(Color.Gray).AddStop(0.6f, new Color(97, 122, 129)))
			};
		}

		public override string Name()
		{
			return "Gohan Forms";
		}

		public override Node[] Nodes()
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			return new Node[2]
			{
				new Node(6f, 0f, "MysticBuff", "GohanForms/Transformations/MysticBuff", "Hit Golem with Z Sword and talk to Kai", (Predicate<Player>)UnlockConditionMystic, (Predicate<Player>)DiscoverConditionMystic, false, (Action<Player>)null),
				new Node(7f, 0f, "BeastBuff", "GohanForms/Transformations/BeastBuff", "MoonLord with half mastered Potential Unleashed (Only for Prodigy)", (Predicate<Player>)UnlockConditionBeast, (Predicate<Player>)DiscoverConditionBeast, false, (Action<Player>)null)
			};
		}

		public bool UnlockConditionMystic(Player player)
		{
			if (player.GetModPlayer<GOHPlayer>().MysticAchieved)
			{
				return player.GetModPlayer<GPlayer>().Trait != "Legendary";
			}
			return false;
		}

		public bool DiscoverConditionMystic(Player player)
		{
			if (NPC.downedGolemBoss || player.GetModPlayer<MyPlayer>().masteryLevel2 != 0f)
			{
				return player.GetModPlayer<GPlayer>().Trait != "Legendary";
			}
			return false;
		}

		public bool UnlockConditionBeast(Player player)
		{
			if (player.GetModPlayer<GOHPlayer>().BeastAchieved)
			{
				return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
			}
			return false;
		}

		public bool DiscoverConditionBeast(Player player)
		{
			if (player.GetModPlayer<GOHPlayer>().MysticAchieved)
			{
				return player.GetModPlayer<GPlayer>().Trait == "Prodigy";
			}
			return false;
		}
	}

	public bool MysticActive;

	public bool MysticUnlockMsg;

	public bool MysticAchieved;

	public bool BeastActive;

	public bool BeastUnlockMsg;

	public bool BeastAchieved;

	public bool MP_Unlock;

	public bool SwordBroke;

	public bool CD;

	public int BeastCharge;

	public int BoostTimer;

	public float BoostPerc;

	public int TimerReduce;

	public Texture2D hair;

	public int lightningFrameTimer;

	private int lightning3FrameTimer = 6;

	private int lightning3FrameTime;

	public int lightning3FrameCount = 9;

	public int lightning3FrameIndex;

	public DateTime? Offset;

	public DateTime? PoweringUpTime;

	public DateTime? LastPowerUpTick;


	public override void PostUpdate()
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		Player val = Main.player[Main.myPlayer];
		GOHPlayer modPlayer = val.GetModPlayer<GOHPlayer>();
		NPC[] npc = Main.npc;
		foreach (NPC val2 in npc)
		{
			if (val2.type == 398 && val2.life <= 25 && !modPlayer.BeastAchieved && val.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<MysticBuff>()) >= 1f && val.GetModPlayer<GPlayer>().Trait == "Prodigy")
			{
				modPlayer.BeastAchieved = true;
				TransformationHandler.ClearTransformations(((ModPlayer)this).Player);
				TransformationHandler.Transform(((ModPlayer)this).Player, TransformationHandler.GetTransformation("BeastBuff").Value);
			}
		}
		if (MysticAchieved && !MysticUnlockMsg)
		{
			MysticUnlockMsg = true;
			Main.NewText("Your potential has been unleashed!", byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
		if (BeastAchieved && !BeastUnlockMsg)
		{
			BeastUnlockMsg = true;
			Main.NewText((object)"You have come even further beyond.", (Color?)Color.SlateBlue);
		}
		if (((ModPlayer)this).Player.HasBuff<BeastBuff>())
		{
			lightningFrameTimer++;
		}
		if (lightning3FrameTime >= lightning3FrameTimer)
		{
			lightning3FrameTime = 0;
			lightning3FrameIndex++;
			if (lightning3FrameIndex >= lightning3FrameCount)
			{
				lightning3FrameIndex = 0;
			}
		}
		if (lightningFrameTimer >= 15)
		{
			lightningFrameTimer = 0;
		}
		if (((ModPlayer)this).Player.HasBuff<BeastBuff>() && TransformationHandler.EnergyChargeKey.Current)
		{
			if (BoostPerc < 1f)
			{
				BeastCharge++;
				if (BeastCharge > 100)
				{
					for (int j = 0; j < 35; j++)
					{
						Vector2 val3 = ((Entity)val).Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-((Entity)val).width - 2), (float)(((Entity)val).width + 2)), Utils.NextFloat(Main.rand, (float)(-((Entity)val).height - 6), (float)(((Entity)val).height + 6)));
						Vector2? val4 = Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(80f));
						Color val5 = default;
						Dust val6 = Dust.NewDustPerfect(val3, 221, val4, 0, val5, 1f);
						Vector2 center = ((Entity)val).Center;
						val5 = Color.Red;
						Lighting.AddLight(center, val5.ToVector3());
						val6.noGravity = true;
						Vector2 val7 = ((Entity)val).Center + new Vector2(Utils.NextFloat(Main.rand, (float)(-((Entity)val).width - 6), (float)(((Entity)val).width + 6)), Utils.NextFloat(Main.rand, (float)(-((Entity)val).height - 6), (float)(((Entity)val).height + 6)));
						Vector2? val8 = Utils.RotatedByRandom(new Vector2(0f, -1.5f), (double)MathHelper.ToRadians(100f));
						val5 = default;
						Dust val9 = Dust.NewDustPerfect(val7, 62, val8, 0, val5, 1f);
						Vector2 center2 = ((Entity)val).Center;
						val5 = Color.DarkViolet;
						Lighting.AddLight(center2, val5.ToVector3());
						val9.noGravity = true;
					}
					BoostPerc += 0.1f;
					BeastCharge = 0;
				}
			}
			TimerReduce = 0;
			BoostTimer = 900;
		}
		else
		{
			if (!((ModPlayer)this).Player.HasBuff<BeastBuff>() || TransformationHandler.EnergyChargeKey.Current)
			{
				return;
			}
			if (BoostTimer >= 1)
			{
				BoostTimer--;
			}
			if (BoostTimer == 0 && BoostPerc > 0.1f)
			{
				TimerReduce++;
				if (TimerReduce > 220)
				{
					BoostPerc -= 0.1f;
					TimerReduce = 0;
				}
			}
		}
	}

	public override void SaveData(TagCompound tag)
	{
		tag.Add("GohanForms_SwordBroke", (object)SwordBroke);
		tag.Add("GohanForms_MysticAchieved", (object)MysticAchieved);
		tag.Add("GohanForms_MysticUnlockMsg", (object)MysticUnlockMsg);
		tag.Add("GohanForms_BeastAchieved", (object)BeastAchieved);
		tag.Add("GohanForms_BeastUnlockMsg", (object)BeastUnlockMsg);
	}

	public override void LoadData(TagCompound tag)
	{
		if (tag.ContainsKey("GohanForms_SwordBroke"))
		{
			SwordBroke = tag.GetBool("GohanForms_SwordBroke");
		}
		if (tag.ContainsKey("GohanForms_MysticAchieved"))
		{
			MysticAchieved = tag.GetBool("GohanForms_MysticAchieved");
		}
		if (tag.ContainsKey("GohanForms_MysticUnlockMsg"))
		{
			MysticUnlockMsg = tag.GetBool("GohanForms_MysticUnlockMsg");
		}
		if (tag.ContainsKey("GohanForms_BeastAchieved"))
		{
			BeastAchieved = tag.GetBool("GohanForms_BeastAchieved");
		}
		if (tag.ContainsKey("GohanForms_BeastUnlockMsg"))
		{
			BeastUnlockMsg = tag.GetBool("GohanForms_BeastUnlockMsg");
		}
	}

	public override void ProcessTriggers(TriggersSet triggersSet)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		Player val = Main.player[Main.myPlayer];
		if (TransformationHandler.EnergyChargeKey.Current && TransformationHandler.TransformKey.JustPressed && BeastAchieved && !((ModPlayer)this).Player.HasBuff<BeastBuff>() && ((ModPlayer)this).Player.HasBuff<MysticBuff>() && val.GetModPlayer<GPlayer>().Trait == "Prodigy" && !CD)
		{
			TransformationHandler.ClearTransformations(((ModPlayer)this).Player);
			TransformationHandler.Transform(((ModPlayer)this).Player, TransformationHandler.GetTransformation("BeastBuff").Value);
		}
	}

	public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (hair != null && !drawInfo.fullHair)
		{
			drawInfo.drawPlayer.head = 0;
		}
		if (BeastActive)
		{
			drawInfo.colorHair = Color.Transparent;
		}
	}
}
