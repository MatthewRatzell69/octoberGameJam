using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsTowerScript : Tower
{

    public ParticleSystem potionDecayParticles;
    public GameObject potionDecayObject;

    private bool spawnOnce = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (towerHealth <= 0.05f && spawnOnce)
        {
            ParticleSystem temp = Instantiate(potionDecayParticles);
            temp.transform.position = transform.position;

            GameObject potionDecayObj = Instantiate(potionDecayObject);
            potionDecayObj.transform.position = transform.position;

            spawnOnce = false;

        }

    }
}
