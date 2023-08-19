using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    [SerializeField]private TMP_Text wrong_answer;
    private int random_num;
    private void Start()
    {
        ShowWrongAnswer(); // I think it is not nessary here
    }
    // Update is called once per frame
    public void ShowWrongAnswer() 
    {
        random_num = Random.Range(-100, 100);
        wrong_answer.text = "" + random_num;
    }
}
