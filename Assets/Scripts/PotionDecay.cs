using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDecay : MonoBehaviour
{
    public float decayRadius;
    public float lifeTime;

    private float timer;

    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = gameManager.enemies;
        timer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {

        timer = timer - Time.deltaTime;

        for(int i = 0; i < enemies.Count; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, transform.position) < decayRadius)
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(Time.deltaTime * 5.0f);
            }
        }

        if(timer <= 0)
        {
            Destroy(gameObject);
        }

    }
}
