using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackOLanternScript : Tower
{
    public float blastRadius;
    public float damage;
    //private List<GameObject> enemies;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //enemies = gameManager.enemies;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //super small number thats greater than zero because inside
        //the base class when health is <= 0, it destroys the tower
        if(towerHealth < 0.05f)
        {
            for(int i = 0; i < enemies.Count; i++)
            {

                float distance = Vector3.Distance(enemies[i].transform.position, transform.position);

                if (distance < blastRadius)
                {

                    Debug.Log((blastRadius / distance) * damage);

                    //coded so that the closer the enemy is, the more damage it'll do
                    enemies[i].GetComponent<Enemy>().TakeDamage((blastRadius / distance) * damage);

                    Destroy(gameObject);

                }
            }
        }

    }
}
