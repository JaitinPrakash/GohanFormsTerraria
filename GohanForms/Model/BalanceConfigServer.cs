using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace GohanForms.Model;

internal class BalanceConfigServer : ModConfig
{
	public static BalanceConfigServer Instance;

	[Label("Rebalanced Stats (Mod Reload Required)")]
	[Tooltip("Self explanatory")]
	[DefaultValue(false)]
	public bool SSJTweaks;

	public override ConfigScope Mode => (ConfigScope)0;
}
