using System.IO;
using GohanForms.Assets;
using Terraria;
using Terraria.ModLoader;

namespace GohanForms.Model;

internal static class GNetworkHandler
{
	public const byte SYNC_UNLOCK_STATUS = 1;

	public static void SendUnlockStatus(int who, bool value)
	{
		ModPacket packet = ((Mod)GohanForms.Instance).GetPacket(256);
		((BinaryWriter)(object)packet).Write((byte)1);
		((BinaryWriter)(object)packet).Write(who);
		((BinaryWriter)(object)packet).Write(value);
		packet.Send(-1, -1);
	}

	public static void ReceiveUnlockStatus(int who, bool value)
	{
		if (Main.netMode == 1)
		{
			Main.player[who].GetModPlayer<GOHPlayer>().MP_Unlock = value;
		}
	}

	public static void HandlePacket(BinaryReader reader, int fromWho)
	{
		if (reader.ReadByte() == 1)
		{
			int who = reader.ReadInt32();
			bool value = reader.ReadBoolean();
			ReceiveUnlockStatus(who, value);
		}
	}
}
