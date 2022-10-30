using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTowerScript : Tower
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

        //set the skeleton's animation to throw briefly
        GetComponent<Animator>().SetBool("throw", true);

        Invoke("SetAnimatorBool", 0.25f);

    }

    private void SetAnimatorBool()
    {
        GetComponent<Animator>().SetBool("throw", false);
    }
}
