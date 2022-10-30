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

    //used for remembering rounds and gold and health
    public static int roundNum;
    public static int gold = 1000;
    public static int health = 100;


    //our 3 enemy types
    public GameObject smallEnemy;
    public GameObject mediumEnemy;
    public GameObject largeEnemy;


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
        shouldSpawnEnemys = false;
        //make sure we call this on start
        RepopulateEnemys();
    }

    // Update is called once per frame
    void Update()
    {
        //temp timer code
        timer = timer - Time.deltaTime;

        
        //make sure we stop spawning when we get to the end of the list, and also reset our count so populate gets called
        if (enemyNumberInList >= enemiesCopy.Count)
        {
            shouldSpawnEnemys = false;
            enemiesCopy.Clear();
        }
        
        //handles the spawning for each round
        if (timer <= 0 && shouldSpawnEnemys)
        {
            

            GameObject temp = Instantiate(enemiesCopy[enemyNumberInList]);
            temp.transform.position = new Vector3(-12f, 4.5f, 0f);

            //make sure its added to the enemy list or it wont get attacked needs to be added after instantiation
            enemies.Add(temp);

            timer = enemySpawnCooldown;

            enemyNumberInList++;
        }

        //if all the enemies are dead
        if (enemies.Count <= 0 && enemiesCopy.Count == 0)
        {
            //repopulate the list
            RepopulateEnemys();
        }

    }

    //function that repopulates the list
    void RepopulateEnemys()
    {
        roundNum++;
        enemiesCopy.Clear();
        Debug.Log("repopulating list");
        //reset enemy number in list
        enemyNumberInList = 0;
        //also make sure we reset if enemys should be spawned
        shouldSpawnEnemys = true;

        for(int i = 0; i <= roundNum; i++)
        {
            enemiesCopy.Add(smallEnemy);
        }
        

        //make sure enemys is equal to the copy list
        //enemies == enemiesCopy;
    }
    //function that populates list
}
