using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    private int score_val = 0;
    private void Update()
    {
        score_val = Spawner.instance.ReturnScore();
        if(score_val <= 9)
        {
            Score.text = "0" + score_val;
        }
        else 
        {
            Score.text = ""+ score_val;
        }
    }
}
