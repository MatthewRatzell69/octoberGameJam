using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RoundAmount : MonoBehaviour
{
    public TMP_Text roundNumber;
    // Start is called before the first frame update
    void Start()
    {
        roundNumber.text = ("Round:" + gameManager.roundNum);
    }

    // Update is called once per frame
    void Update()
    {
        roundNumber.text = ("Round:" + gameManager.roundNum);
    }
}
