using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace GohanForms.Assets;

public class CanKaiSpawn : ModSystem
{
	internal static bool _SwordBroke;

	public static bool SwordBroke
	{
		get
		{
			return _SwordBroke;
		}
		set
		{
			if (!value)
			{
				_SwordBroke = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _SwordBroke, -1);
			}
		}
	}

	internal static void ResetAllFlags()
	{
		SwordBroke = false;
	}

	public override void OnWorldLoad()
	{
		ResetAllFlags();
	}

	public override void OnWorldUnload()
	{
		ResetAllFlags();
	}

	public override void SaveWorldData(TagCompound tag)
	{
		List<string> list = new List<string>();
		if (SwordBroke)
		{
			list.Add("Zsword");
		}
		tag["downedFlags"] = list;
	}

	public override void LoadWorldData(TagCompound tag)
	{
		SwordBroke = tag.GetList<string>("downedFlags").Contains("Zsword");
	}
}
