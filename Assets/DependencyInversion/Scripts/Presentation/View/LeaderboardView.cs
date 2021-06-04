namespace CaseStudyDependencyInversion.Unity.Presentation.View
{
	using CaseStudyDependencyInversion.Unity.Domain;
	using CaseStudyDependencyInversion.Unity.Domain.Model;
	using System.Linq;
	using System.Text;
	using UnityEngine;

	public class LeaderboardView : MonoBehaviour
	{
		int index;

		protected virtual void Start()
		{
			var leaderboard = new LeaderboardController();
			leaderboard.GetItems()
				.ToList()
				.ForEach(i => Debug.Log(this.PrintLeaderboardItem(i)));
		}

		string PrintLeaderboardItem(LeaderboardItem leaderboardItem)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append($"Index: {++this.index}, ");
			stringBuilder.Append($"{nameof(LeaderboardItem.Name)}: {leaderboardItem.Name}, ");
			stringBuilder.Append($"{nameof(LeaderboardItem.Score)}: {leaderboardItem.Score}, ");

			return stringBuilder.ToString();
		}
	}
}
