using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BinaryChoiceDialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMPro.TextMeshProUGUI textBox;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private string dialogue;

    [SerializeField] private UnityEvent onStartUp;
    [SerializeField] private UnityEvent onYes;
    [SerializeField] private UnityEvent onNo;
    [SerializeField] private UnityEvent onChoiceMade;


    public void BinaryChoice()
    {
        onStartUp?.Invoke();
        yesButton?.onClick.AddListener(SpeedUp);
        noButton?.onClick.AddListener(OnNo);
        textBox.text = dialogue;
    }

    private void SpeedUp()
    {
        onYes?.Invoke();
        End();
    }

    private void OnNo()
    {
        onNo?.Invoke();
        End();
    }
    
    private void End()
    {
        onChoiceMade?.Invoke();
        yesButton?.onClick.RemoveListener(SpeedUp);
        noButton?.onClick.RemoveListener(OnNo);
    }
    
}
