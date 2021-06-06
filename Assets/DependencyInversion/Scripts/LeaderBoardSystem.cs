using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardSystem
{
    public readonly ILeaderBoard IleaderBoard;
    public LeaderBoardSystem(ILeaderBoard IleaderBoard,int SortType)
    {
        // any ILeaderboard interfaced class may add in this  part
        // we may change dependency based on need to other sorting types
        if (SortType == 0)
        {
            this.IleaderBoard = new LeaderBoardByScore();
        }
        else
        {
            this.IleaderBoard = new LeaderBoardByName();
        }
    }
}
