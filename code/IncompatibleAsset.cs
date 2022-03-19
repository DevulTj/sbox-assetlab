
using Sandbox;
using System.Collections.Generic;
using System.ComponentModel;

[Library( "e_resource" ), AutoGenerate]
public partial class IncomatibleAsset : Asset
{
	public static List<IncomatibleAsset> All { get; set; } = new();

	public static IncomatibleAsset Random => All[Rand.Int( All.Count - 1 )];

	[Property, Category( "Meta" )]
	public string ItemName { get; set; }

	[Property, Category( "Meta" )]
	public string ItemDescription { get; set; }

	[Property, Category( "Meta" ), Range( 0, 256 )]
	public int StackSize { get; set; } = 1;

	[Property, Category( "Meta" ), ResourceType( "png" )]
	public string IconPath { get; set; }

	[Property, Category( "World" ), ResourceType( "vmdl" )]
	public string WorldModelPath { get; set; }

	[Property, Category( "Crafting" )]
	public int CraftingDuration { get; set; }

	[Property, Category( "Crafting" )]
	public CraftingRecipe Recipe { get; set; }

	public Model WorldModel { get; set; }

	public static Model FallbackWorldModel = Model.Load( "models/sbox_props/bin/rubbish_bag.vmdl" );

	protected override void PostLoad()
	{
		base.PostLoad();

		Log.Info( "Loading game asset: " + Name );
		All.Add( this );
	}
}
