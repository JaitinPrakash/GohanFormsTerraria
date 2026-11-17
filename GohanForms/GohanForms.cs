using System.IO;
using GohanForms.Model;
using Terraria.ModLoader;

namespace GohanForms;

public class GohanForms : Mod
{
	public static GohanForms Instance;

	public static Mod DBZMOD;

	public static Mod DBCA;

	public static Mod GOATLIB;

	public override void HandlePacket(BinaryReader reader, int whoAmI)
	{
		GNetworkHandler.HandlePacket(reader, whoAmI);
	}

	public override void Load()
	{
		Instance = this;
	}
}
