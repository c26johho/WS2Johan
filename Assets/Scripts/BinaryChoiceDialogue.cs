using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BinaryChoiceDialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textBox;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private string dialogue;

    [SerializeField] private UnityEvent onStartUp;
    [SerializeField] private UnityEvent onYes;
    [SerializeField] private UnityEvent onNo;
    [SerializeField] private UnityEvent onChoiceMade;

    // Start by activating the buttons to their respective response-function. Add text to scene.
    public void BinaryChoice()
    {
        onStartUp?.Invoke();
        yesButton?.onClick.AddListener(OnYes);
        noButton?.onClick.AddListener(OnNo);
        textBox.text = dialogue;
    }
    // The function that gets called when yesButton is pressed.
    private void OnYes()
    {
        onYes?.Invoke();
        EndDialogue();
    }

    // The function that gets called when noButton is pressed.
    private void OnNo()
    {
        onNo?.Invoke();
        EndDialogue();
    }
    
    // Ending the dialogue by calling an event and unsubscribing the buttons from their respective event.
    private void EndDialogue()
    {
        onChoiceMade?.Invoke();
        yesButton?.onClick.RemoveListener(OnYes);
        noButton?.onClick.RemoveListener(OnNo);
    }
    
}
