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
            // dis class gets suitable dependency based on sorting type
            leaderBoardSystem = new LeaderBoardSystem(leaderBoard, sortType);
            return leaderBoardSystem.IleaderBoard.Sort(leaderboardProvider); 
        }
    }
}
