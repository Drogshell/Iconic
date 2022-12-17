using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public GameManager manager;

    private VisualElement _root;
    private Label _hint;
    private Label _hintNumberLabel;
    private Label _questionNumberLabel;
    private Label _timeLabel;
    private Label _answerIndicator;
    private Label _highScoreLabel;
    private Label _currentScoreLabel;
    private Button _nextHintButton;
    
    private void OnEnable()
    {
       _root = GetComponent<UIDocument>().rootVisualElement;

       _hint = _root.Q<Label>("Hint");
       _hintNumberLabel = _root.Q<Label>("HintNumber");
       _questionNumberLabel = _root.Q<Label>("QuestionCounter");
       _timeLabel = _root.Q<Label>("CounterLabel");
       _answerIndicator = _root.Q<Label>("AnswerIndicator");
       _highScoreLabel = _root.Q<Label>("HighScore");
       _currentScoreLabel = _root.Q<Label>("CurrentScore");

       _nextHintButton = _root.Q<Button>("NextHintButton");

    }

    public void SetHint(string hintText)
    {
        _hint.text = hintText;
    }

    public void SetHintNumber(int hintNumber)
    {
        _hintNumberLabel.text = $"Hint {hintNumber.ToString()}:";
    }

    public void SetQuestionNumber(int questionNumber)
    {
        _questionNumberLabel.text = $"Question {questionNumber}";
    }
}
