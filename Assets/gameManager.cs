using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    //the currently selected monster in the shop, right now being preset to the skeleton
    public static string monsterSelected;

    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> decayCircles = new List<GameObject>();
    //list that can be used along with our timer so that as enemys are removed from the enemies list we still know which ones to spawn in
    public static List<GameObject> enemiesCopy = new List<GameObject>();

    //used for remembering rounds and gold
    public static int roundNum;
    public static int gold;

    public GameObject testEnemy;
    //used for the timer function
    private float timer;
    private float enemySpawnCooldown;

    //remembers what number we are at in the list 
    private int enemyNumberInList;

    //bool that determines if enemys should be spawned at the moment
    private bool shouldSpawnEnemys;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnCooldown = 2.0f;
        timer = enemySpawnCooldown;
        roundNum = 0;
        enemyNumberInList = 0;

        enemiesCopy = enemies;
        //need to put everything in here for the first round spawning
    }

    // Update is called once per frame
    void Update()
    {
        //if all the enemies are dead
        if (enemies.Count <= 0)
        {
            //increase round count
            roundNum++;
            RepopulateEnemys();
        }

        //temp timer code
        timer = timer - Time.deltaTime;

        //handles the spawning for each round
        if (timer <= 0 && enemies.Count>0 && shouldSpawnEnemys)
        {
            Debug.Log("Spawning Enemy");
            GameObject temp = Instantiate(enemiesCopy[enemyNumberInList]);
            temp.transform.position = new Vector3(-12f, 4.5f, 0f);
            enemies.Add(temp);
            timer = enemySpawnCooldown;

            

            //make sure we stop spawning when we get to the end of the list
            if(enemyNumberInList < enemiesCopy.Count)
            {
                shouldSpawnEnemys = false;
            }

            enemyNumberInList++;
        }

        //Debug.Log("Enemies Count:" + enemies.Count);
    }

    //function that repopulates the list
    void RepopulateEnemys()
    {
        Debug.Log("repopulating list");
        //reset enemy number in list
        enemyNumberInList = 0;
        //also make sure we reset if enemys should be spawned
        shouldSpawnEnemys = true;


        GameObject temp = Instantiate(testEnemy);
        temp.transform.position = new Vector3(-12f, 4.5f, 0f);
        enemies.Add(temp);





        //after repopulating the list we have to make sure we set the copy
        enemiesCopy = enemies;
    }
    //function that populates list
}
