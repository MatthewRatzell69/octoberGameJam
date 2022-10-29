using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    //the currently selected monster in the shop, right now being preset to the skeleton
    public static string monsterSelected;

    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> decayCircles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
