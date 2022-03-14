
using Sandbox;

public partial class AssetCollection : BaseNetworkable
{
	[Net]
	public TestAsset One { get; set; }

	[Net]
	public TestAsset Two { get; set; }
}
