namespace CaseStudyDependencyInversion.Unity.Domain
{
    using CaseStudyDependencyInversion.Unity.Domain.Model;
    using System.Collections.Generic;
    using UnityEngine;

    public class LeaderboardController
    {
        private ILeaderBoard leaderBoard;
        private LeaderBoardSystem leaderBoardSystem;
        public IEnumerable<LeaderboardItem> GetItems()
        {
            var leaderboardProvider = new FakeLeaderboardProvider();
            var sortType = PlayerPrefs.GetInt("SortType", 0);
            leaderBoardSystem = new LeaderBoardSystem(leaderBoard, sortType);
            var rslt= leaderBoardSystem.IleaderBoard.Sort(leaderboardProvider);
            return rslt;
        }
    }
}
