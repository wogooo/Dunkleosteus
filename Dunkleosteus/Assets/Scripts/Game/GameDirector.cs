﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour {

    public GameObject startPanelTest;
    public GameObject playPanel;
    public LevelPlayMgr levelMgr;

    private FiniteStateMachine _fsm;
	
    void Awake() {
        // Init template data
        TemplateMgr.Instance.Init();
        // Init finite state machine
        InitFiniteStateMachine();
    }

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Debug.Log("GameDirector.StartGame");
        startPanelTest.SetActive(false);
        levelMgr.LoadLevel("Scorpius");
        playPanel.SetActive(true);
    }

    public void TriggerTransition(StateTransition trans)
    {
        _fsm.PerformTransition(trans);
    } 

    private void InitFiniteStateMachine()
    {
        // Init all states
        MainMenuState mainMenu = new MainMenuState(this);
        mainMenu.AddTransition(StateTransition.PressStart, StateID.LevelSelect);

        LevelSelectState levelSelect = new LevelSelectState(this);
        levelSelect.AddTransition(StateTransition.ViewOption, StateID.OptionMenu);
        levelSelect.AddTransition(StateTransition.ViewCredit, StateID.CreditView);
        levelSelect.AddTransition(StateTransition.ViewCard, StateID.CardView);
        levelSelect.AddTransition(StateTransition.ChoseLevel, StateID.GameScene);

        OptionMenuState optionMenu = new OptionMenuState(this);
        optionMenu.AddTransition(StateTransition.BackToLevelSelect, StateID.LevelSelect);

        CreditViewState creditView = new CreditViewState(this);
        creditView.AddTransition(StateTransition.BackToLevelSelect, StateID.LevelSelect);

        CardViewState cardView = new CardViewState(this);
        cardView.AddTransition(StateTransition.BackToLevelSelect, StateID.LevelSelect);

        GameSceneState gameScene = new GameSceneState(this);
        gameScene.AddTransition(StateTransition.BackToLevelSelect, StateID.LevelSelect);

        // Init finite state machine
        _fsm = new FiniteStateMachine();
        _fsm.AddFiniteState(mainMenu);
        _fsm.AddFiniteState(levelSelect);
        _fsm.AddFiniteState(optionMenu);
        _fsm.AddFiniteState(creditView);
        _fsm.AddFiniteState(cardView);
        _fsm.AddFiniteState(gameScene);s
    }


}
