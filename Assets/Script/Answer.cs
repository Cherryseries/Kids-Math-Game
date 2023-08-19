using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private TMP_Text answer_text;
    private void Update()
    {
        answer_text.text = "" + MathManager.instance.answer;
    }
}
