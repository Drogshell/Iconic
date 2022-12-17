using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Question> questions = new List<Question>();

    private Question _currentQuestion;
    private int _questionIndex = 0;

    private string _currentHint;
    private int _hintIndex = 0;

    public void InitialiseGame()
    {
        _currentQuestion = questions[_questionIndex];
        _currentHint = _currentQuestion.GetHints()[_hintIndex];
    }

    public bool IsAnswerCorrect(string answer)
    {
        return _currentQuestion.answer == answer;
    }

    public void HandleCorrectAnswer()
    {
        NextQuestion();
    }
    
    public void HandleIncorrectAnswer()
    {
        if (_hintIndex < 2)
        {
            _currentHint = _currentQuestion.GetHints()[++_hintIndex];
        }
        else
        {
            NextQuestion();
        }
    }

    public void NextQuestion()
    {
        _currentQuestion = questions[++_questionIndex];

        _hintIndex = 0;

        _currentHint = _currentQuestion.GetHints()[_hintIndex];
    }

    public Question GetCurrentQuestion()
    {
        return _currentQuestion;
    }

    public int GetCurrentQuestionNumber()
    {
        return _questionIndex + 1;
    }

    public string GetCurrentHint()
    {
        return _currentHint;
    }

    public int GetCurrentHintNumber()
    {
        return _hintIndex + 1;
    }
}
