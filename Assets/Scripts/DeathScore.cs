using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DeathScore : MonoBehaviour
{
    public TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Your score\n" +ScoreManager.scoreCount.ToString();
    }

    // Update is called once per frame
  
}
