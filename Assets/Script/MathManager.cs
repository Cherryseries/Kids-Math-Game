using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathManager : MonoBehaviour
{
    public static MathManager instance;
    private void Start()
    {
        QuestionGen();
    }
    private void Awake()
    {
        instance = this;
    }
    [SerializeField]private TMP_Text question;
    private int firstNumber;
    private int secondNumber;
    private int symbolsNum;  
    public int answer;
    private List<string> symbols = new List<string>() {"+","-","x","/"};
   
    public void QuestionGen()
    {

        firstNumber = Random.Range(0, 9);
        secondNumber = Random.Range(0, 9);
        symbolsNum = Random.Range(0, 3);
        question.text = firstNumber + symbols[symbolsNum] + secondNumber;
        if (symbolsNum == 0)
        {
            int sum = firstNumber + secondNumber;
            answer = sum;
        }
        if (symbolsNum == 1)
        {
            int sub = firstNumber - secondNumber;
            answer = sub;
        }
        if (symbolsNum == 2)
        {
            int mul = firstNumber * secondNumber;
            answer = mul;
        }
        if (symbolsNum == 3)
        {
            int div = firstNumber / secondNumber;
            answer = div;
        }
    }
}
