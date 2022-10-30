using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MoneyAmount : MonoBehaviour
{
    public TMP_Text moneyAmount;
    // Start is called before the first frame update
    void Start()
    {
        moneyAmount.text = ("Gold:" + gameManager.gold);
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount.text = ("Gold:" + gameManager.gold);
    }
}
