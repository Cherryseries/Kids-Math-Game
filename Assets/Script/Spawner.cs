using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{ 
    [SerializeField] private List<GameObject> fallingObjects;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject _score_text_Rp;
    [SerializeField] private GameObject _score_Rp;
    [SerializeField] private GameObject Question;

    [SerializeField] private TMP_Text score_text;
    [SerializeField] private TMP_Text total_score;
    [SerializeField] private TMP_Text time;

    public bool timeUp ;
    private bool _stuck;

    private int minute = 2;
    private int second = 59;
    private int milisec = 59;

    private int score = 0;

    public static Spawner instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(SpawnAnswer());
    }
    private void Update()
    {
        _stuck = UiManager.instance.ReturnStuck();
        score_text.text = "SCORE : " + score;
        if (!timeUp && !_stuck) 
        {
            SpawnSec();
        }

        if (minute < 0 )
        {
            minute = 0;
            second = 0;
            timeUp = true;
           // Debug.Log("timeup");
            restartPanel.SetActive(true);
            Time.timeScale = 0f;
            _score_Rp.SetActive(true);
            _score_text_Rp.SetActive(true);
            Question.SetActive(false);
           /** for (int i = 0; i < 5; i++) 
            {
                Destroy(fallingObjects[i]);
            }**/
        }

        if (milisec == 0) 
        {
            second--;
            milisec = 59;
        }

        if (second < 0)
        {
            second = 59;
            minute--;
        }

        if (second <= 9) 
        {
            time.text = "0" + minute + ":" + "0" + second;
        }
       
        if (minute > 9)
        {
            time.text = minute + ":" + "0" + second;
        }
        if(second > 9)
        {
            time.text = "0" + minute + ":" + second;
        }
    }
    
    public void SpawnAnswers() 
    {

        Vector3 spawnPos1 = new Vector3(-2f, Random.Range(5.5f, 8f), 0);
        Vector3 spawnPos2 = new Vector3(-1f, Random.Range(5.5f, 8f), 0);
        Vector3 spawnPos3 = new Vector3(-0f, Random.Range(5.5f, 8f), 0);
        Vector3 spawnPos4 = new Vector3( 1f, Random.Range(5.5f, 8f), 0);
        Vector3 spawnPos5 = new Vector3( 2f, Random.Range(5.5f, 8f), 0);

        List<Vector3> spawnPos = new List<Vector3>() {spawnPos1,spawnPos2,spawnPos3,spawnPos4,spawnPos5};

        List<int> possibleNumbers = new List<int> { 0, 1, 2, 3, 4};
        List<int> selectedNumbers = new List<int>();
        int numbersToSelect = 5;

        for (int i = 0; i < numbersToSelect; i++)
        {
            int randomIndex = Random.Range(0, possibleNumbers.Count);
            int randomNumber = possibleNumbers[randomIndex];
            selectedNumbers.Add(randomNumber);
            possibleNumbers.RemoveAt(randomIndex);
        }

        int sequence = 0;
        foreach (int number in selectedNumbers)
        {   
           // Debug.Log("Selected Number: " + number + sequence + spawnPos[sequence]);
            Instantiate(fallingObjects[number], spawnPos[sequence] , Quaternion.identity);
            sequence++;
        }
        
    }
    public void Update_score()
    {
        score++;
    }

    IEnumerator SpawnAnswer() 
    {
        while (true) 
        {
            SpawnAnswers();
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator spawnsec() 
    {
        milisec--;
        yield return new WaitForSecondsRealtime(1000*Time.deltaTime);
    }

    public int ReturnScore()
    {
        return score;
    }

    public void SpawnSec() 
    {
        StartCoroutine(spawnsec());
    }
}
