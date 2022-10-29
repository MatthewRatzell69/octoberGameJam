using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerScript : Tower
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
        Vector3 targetPosition = targetedEnemy.transform.position + (targetedEnemy.GetComponent<Enemy>().moveDir * futureTargetPositionMultiplier);
        projectile.GetComponent<ProjectileMovement>().moveDirection = Vector3.Normalize(targetPosition - transform.position);
    }
}
