using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameText : MonoBehaviour
{
    public TMP_Text maxRoundAchieved;
    // Start is called before the first frame update
    void Start()
    {
        maxRoundAchieved.text = ("Highest Round Achieved: " + gameManager.roundNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
