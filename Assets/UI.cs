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
        
       Initialise();
    }

    public void Initialise()
    {
        _nextHintButton.clicked += () => { manager.GM_HandleIncorrectAnswer(); };
        
        Setup.InitialiseDragDrop(_root, manager);
        Setup.InitialiseIcons(_root, manager.GetAllQuestions());
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

    public void NotifyUserOfAnswer(bool isCorrect)
    {
        _answerIndicator.style.visibility = Visibility.Visible;
        _answerIndicator.text = isCorrect ? "Correct!" : "Incorrect!";

        StyleColor correctColour = new StyleColor(new Color32(106,176,76, 255));
        StyleColor incorrectColour = new StyleColor(new Color32(235, 77, 75, 255));

        _answerIndicator.style.color = isCorrect ? correctColour : incorrectColour;

        StartCoroutine(CleanUpQuestion());
    }

    private IEnumerator CleanUpQuestion()
    {
        yield return new WaitForSeconds(2);
        
        _answerIndicator.style.visibility = Visibility.Hidden;

        VisualElement dropZone = _root.Q<VisualElement>("DropArea");

        if (dropZone.childCount > 0)
        {
            dropZone.RemoveAt(0);
        }
    }
}
