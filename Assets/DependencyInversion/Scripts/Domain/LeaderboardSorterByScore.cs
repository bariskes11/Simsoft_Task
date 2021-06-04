namespace CaseStudyDependencyInversion.Unity.Domain
{
	using CaseStudyDependencyInversion.Unity.Domain.Model;
	using System.Collections.Generic;
	using System.Linq;

	public class LeaderboardSorterByScore
	{
		public IEnumerable<LeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider) =>
			leaderboardProvider.GetItems().OrderByDescending(i => i.Score);
	}
}
