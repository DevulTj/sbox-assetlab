
using Sandbox;
using System.Collections.Generic;

[Library( "test" ), AutoGenerate]
public partial class TestAsset : Asset
{
	public static List<TestAsset> All { get; set; } = new();

	public static TestAsset Random => All[Rand.Int( All.Count - 1 )];

	[Property]
	public string TestValue { get; set; } = "Testing";

	protected override void PostLoad()
	{
		base.PostLoad();

		Log.Info( "Loading game asset: " + Name );
		All.Add( this );
	}
}
