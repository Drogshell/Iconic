using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Game game;
    public UI ui;

    private int _counter;

    public int Counter 
    { 
        get => _counter;
        private set {
            if (value == 0)
            {
                GM_HandleIncorrectAnswer();
                return;
            }
            
            // Update the UI
            _counter = value;
        }
    }
    
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

    public void CheckAnswer(string answer)
    {
        bool isAnswerCorrect = game.IsAnswerCorrect(answer);

        if (isAnswerCorrect)
        {
            GM_HandleCorrectAnswer();
        }
        else
        {
            GM_HandleIncorrectAnswer();
        }
        
        ui.NotifyUserOfAnswer(isAnswerCorrect);
    }
    
    public void GM_UpdateUI()
    {
        ui.SetHint(game.GetCurrentHint());
        ui.SetHintNumber(game.GetCurrentHintNumber());
        ui.SetQuestionNumber(game.GetCurrentQuestionNumber());
    }

    public List<Question> GetAllQuestions()
    {
        return game.questions;
    }

    void ResetCounter()
    {
        Counter = 30;
    }
    IEnumerator UpdateCounter()
    {
        yield return new WaitForSeconds(1);
        Counter--;
        StartCoroutine(UpdateCounter());
    }
}
