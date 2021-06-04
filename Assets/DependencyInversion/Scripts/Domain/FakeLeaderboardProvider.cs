namespace CaseStudyDependencyInversion.Unity.Domain
{
	using CaseStudyDependencyInversion.Unity.Domain.Model;
	using System.Collections.Generic;

	public class FakeLeaderboardProvider
	{
		const int count = 10;

		public IEnumerable<LeaderboardItem> GetItems()
		{
			for (var i = 1; i <= count; i++)
			{
				yield return new LeaderboardItem
				{
					Name = "Name " + i,
					Score = (count - (i - 1)) * 10
				};
			}
		}
	}
}
