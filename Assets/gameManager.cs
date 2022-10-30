using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    //the currently selected monster in the shop, right now being preset to the skeleton
    public static string monsterSelected;

    public static List<GameObject> enemies;// = new List<GameObject>();
    public static List<GameObject> decayCircles;// = new List<GameObject>();
    //list that can be used along with our timer so that as enemys are removed from the enemies list we still know which ones to spawn in
    public static List<GameObject> enemiesCopy;// = new List<GameObject>();

    //used for remembering rounds and gold and health
    public static int roundNum;
    public static int gold = 100;
    public static int health = 50;


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
        enemies = new List<GameObject>();
        decayCircles = new List<GameObject>();
        //list that can be used along with our timer so that as enemys are removed from the enemies list we still know which ones to spawn in
        enemiesCopy = new List<GameObject>();
        enemySpawnCooldown = 2f;
        timer = enemySpawnCooldown;
        roundNum = 0;
        enemyNumberInList = 0;
        shouldSpawnEnemys = false;
        gold = 100;
        health = 50;
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
       
            GameObject enemyToSpawn = Instantiate(enemiesCopy[enemyNumberInList]);
            enemyToSpawn.transform.position = new Vector3(-12f, 4.5f, 0f);
            //make sure its added to the enemy list or it wont get attacked needs to be added after instantiation
            enemies.Add(enemyToSpawn);
            timer = enemySpawnCooldown;
            enemyNumberInList++;
        }

        //if all the enemies are dead
        if (enemies.Count <= 0 && enemiesCopy.Count == 0)
        {
            //repopulate the list
            RepopulateEnemys();
        }


        //lost condition
        if (health <= 0)
        {
            EndGame();
            Debug.Log("Game Over");
        }

    }

    //function that repopulates the list
    void RepopulateEnemys()
    {
        roundNum++;
        enemiesCopy.Clear();
        //Debug.Log("repopulating list");
        //reset enemy number in list
        enemyNumberInList = 0;
        //also make sure we reset if enemys should be spawned
        shouldSpawnEnemys = true;

        //round 1
        if(roundNum == 1)
        {
            enemiesCopy.Add(smallEnemy);
            enemiesCopy.Add(smallEnemy);
        }
        //round 2
        else if (roundNum == 2)
        {
            enemiesCopy.Add(smallEnemy);
            enemiesCopy.Add(smallEnemy);
            enemiesCopy.Add(mediumEnemy);
        }
        //rounds 3-9
        else if (roundNum >2 && roundNum <10 )
        {
            for (int i = 0; i <= (roundNum * 2); i++)
            {
                //grab a number 1-3
                int randNum = Random.Range(0, 10);

                //50% chance
                if (randNum <= 4)
                {
                    enemiesCopy.Add(smallEnemy);
                    Debug.Log("Spawning Small Enemy");
                }
                //30% chance
                else if (randNum > 4 && randNum <= 8)
                {
                    enemiesCopy.Add(mediumEnemy);
                    Debug.Log("Spawning Medium Enemy");
                }
                else
                {
                    Debug.Log("This shouldnt fire, but if you see this message, make sure you didnt miss a number");
                }

            }
        }
        //on round ten 1 large enemy
        else if(roundNum == 10)
        {
            enemiesCopy.Add(mediumEnemy);
            enemiesCopy.Add(mediumEnemy);
            enemiesCopy.Add(mediumEnemy);
            enemiesCopy.Add(largeEnemy);
        }
        //past round 10 non-random distribution
        else
        {

            for (int i = 0; i <= (roundNum * 2); i++)
            {
                //grab a number 1-3
                int randNum = Random.Range(0, 10);

                //50% chance
                if (randNum <= 4)
                {
                    enemiesCopy.Add(smallEnemy);
                    Debug.Log("Spawning Small Enemy");
                }
                //40% chance
                else if (randNum > 4 && randNum <= 8)
                {
                    enemiesCopy.Add(mediumEnemy);
                    Debug.Log("Spawning Medium Enemy");
                }
                //10% chance
                else if (randNum > 8 && randNum <= 10)
                {
                    enemiesCopy.Add(largeEnemy);
                    Debug.Log("Spawning Large Enemy");
                }
                else
                {
                    Debug.Log("This shouldnt fire, but if you see this message, make sure you didnt miss a number");
                }
            }
        }
        
        //increase the speed at which enemys are spawned each round, but only to a certain point
        if(timer >= .5f)
        {
            timer =- .2f;
        }

    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGameScreen");
    }

}
