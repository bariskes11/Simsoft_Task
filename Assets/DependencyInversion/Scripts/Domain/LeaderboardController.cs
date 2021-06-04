namespace CaseStudyDependencyInversion.Unity.Domain
{
	using CaseStudyDependencyInversion.Unity.Domain.Model;
	using System.Collections.Generic;
	using UnityEngine;

	public class LeaderboardController
	{
		public IEnumerable<LeaderboardItem> GetItems()
		{
			var leaderboardProvider = new FakeLeaderboardProvider();
			var sortType = PlayerPrefs.GetInt("SortType", 0);
			if (sortType == 0)
			{
				return new LeaderboardSorterByScore().Sort(leaderboardProvider);
			}

			return new LeaderboardSorterByName().Sort(leaderboardProvider);
		}
	}
}
