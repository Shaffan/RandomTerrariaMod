using Terraria.ModLoader;

namespace RandomCustomItems
{
	class RandomCustomItems : Mod
	{
		public RandomCustomItems()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
