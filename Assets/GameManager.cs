using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Game game;
    public UI ui;

    private void Start()
    {
        GM_Initialise();
    }

    public void GM_Initialise()
    {
        game.InitialiseGame();
        GM_UpdateUI();
    }
    
    public void GM_HandleIncorrectAnswer()
    {
        game.HandleIncorrectAnswer();
        GM_UpdateUI();
    }

    public void GM_HandleCorrectAnswer()
    {
        game.HandleCorrectAnswer();
        GM_UpdateUI();
    }
    
    public void GM_UpdateUI()
    {
        ui.SetHint(game.GetCurrentHint());
        ui.SetHintNumber(game.GetCurrentHintNumber());
        ui.SetQuestionNumber(game.GetCurrentQuestionNumber());
    }
    
}
