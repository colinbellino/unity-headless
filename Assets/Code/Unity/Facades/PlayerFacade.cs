using Greed.Core;

namespace Greed.Unity
{
	public class PlayerFacade : IPlayer
	{
		public IEntity Head { get; set; }
		public IEntity Body { get; set; }

		public PlayerFacade(IEntity head, IEntity body)
		{
			Head = head;
			Body = body;
		}
	}
}
