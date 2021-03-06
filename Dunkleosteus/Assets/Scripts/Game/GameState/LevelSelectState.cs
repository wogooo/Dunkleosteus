using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectState : FiniteState
{
    public GameDirector gameDirector;

    public LevelSelectState(GameDirector director)
    {
        gameDirector = director;
        _stateID = StateID.LevelSelect;
    }

    public override void DoBeforeEnter() 
    {
        gameDirector.EnterLevelSelectState();
    }

    public override void DoBeforeExit()
    {
        gameDirector.ExitLevelSelectState();
    }
}