
using Sandbox;
using System.Collections.Generic;
using System.ComponentModel;

public class CraftingEntry
{
	[Property]
	public string ItemId { get; set; }
	[Property]
	public int Amount { get; set; } = 0;
}

public class CraftingRecipe
{
	[Property]
	public List<CraftingEntry> Items { get; set; }

	[Property]
	public int Output { get; set; } = 1;
}

public struct CraftingRecipeAsStruct
{
	[Property]
	public List<CraftingEntry> Items { get; set; }

	[Property]
	public int Output { get; set; } = 1;
}

[Library( "test" ), AutoGenerate]
public partial class TestAsset : Asset
{
	public static List<TestAsset> All { get; set; } = new();

	public static TestAsset Random => All[Rand.Int( All.Count - 1 )];

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

	[Property, Category(" Struct" )]
	public CraftingRecipeAsStruct RecipeStruct { get; set; }

	public Model WorldModel { get; set; }

	public static Model FallbackWorldModel = Model.Load( "models/sbox_props/bin/rubbish_bag.vmdl" );

	protected override void PostLoad()
	{
		base.PostLoad();

		Log.Info( "Loading game asset: " + Name );
		All.Add( this );
	}
}
