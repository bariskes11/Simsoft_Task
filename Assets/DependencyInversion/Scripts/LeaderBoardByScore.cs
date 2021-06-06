using CaseStudyDependencyInversion.Unity.Domain;
using CaseStudyDependencyInversion.Unity.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoardByScore: ILeaderBoard
{

    public IEnumerable<LeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider)=>
            leaderboardProvider.GetItems().OrderByDescending(i => i.Score);
}
