namespace Greed.Core
{
	public interface IPlayer
	{
		IEntity Head { get; set; }
		IEntity Body { get; set; }
	}
}
