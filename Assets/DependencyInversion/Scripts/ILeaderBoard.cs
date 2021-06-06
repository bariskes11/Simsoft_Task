using CaseStudyDependencyInversion.Unity.Domain;
using CaseStudyDependencyInversion.Unity.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILeaderBoard 
{
    // main interface for sorting system
    IEnumerable<LeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider);
}
