using System.Collections.Generic;

namespace CustomerMaintenance
{
	public interface IStateDB
	{
		List<State> GetStates();
	}
}