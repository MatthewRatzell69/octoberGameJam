using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    static List<GameObject> enemies;
    public List<GameObject> enemyTypes;

    private int numberOfDifferentEnemyTypes;

    //temp enemy spawn timer
    private float timer;
    public float enemySpawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        timer = enemySpawnCooldown; //temp
        numberOfDifferentEnemyTypes = enemyTypes.Count;

        enemies = gameManager.enemies;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //temp timer code
        timer = timer - Time.deltaTime;

        //temporary enemy spawn code
        if(timer <= 0)
        {
            Debug.Log("Spawning Enemy");
            GameObject temp = Instantiate(enemyTypes[Random.Range(0, numberOfDifferentEnemyTypes)]);
            temp.transform.position = new Vector3(-12f, 4.5f, 0f);
            gameManager.enemies.Add(temp);
            timer = enemySpawnCooldown;
        }
        */
    }
}
