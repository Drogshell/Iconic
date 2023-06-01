using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Helper Class to set up the UI of the game.
/// Removes code in the main UI class to keep things clean
/// </summary>
public class Setup
{
    public static void InitialiseDragDrop(VisualElement root, GameManager manager)
    {
        root.Query<VisualElement>("IconBoard").Children<VisualElement>()
            .ForEach((elem) => elem.AddManipulator(new IconDragger(root, manager)));
    }

    public static void InitialiseIcons(VisualElement root, List<Question> questions)
    {
        int currentIconIndex = 0;

        foreach (var question in questions)
        {
            VisualElement questionIcon = root.Query<VisualElement>("IconBoard").Children<VisualElement>()
                .AtIndex(currentIconIndex);
            questionIcon.style.backgroundImage = Resources.Load<Texture2D>($"Images/{question.answer}");
            
            // This line allows us to retrieve the answer of the icon once it's been dragged over to the drop zone
            questionIcon.userData = question;

            currentIconIndex++;
        }
    }
}