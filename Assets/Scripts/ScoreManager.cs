using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text Score;
    public static int scoreCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        Score.text = scoreCount.ToString();
    }

    // Update is called once per frame
    
    public void AddPoint()
    {
        scoreCount++;
        Score.text = scoreCount.ToString();
    }
    

}

