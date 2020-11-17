using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BossBrick : Brick
{
    protected override void DestroyAction()
    {
        //base.DestroyAction();
        Debug.Log("==== BOSS DAMAGE ! ====");
        Boss _boss = FindObjectOfType<Boss>();
        _boss.TakeDamage(1f);
        Destroy(this.gameObject);

        _boss.brickGenerator.Invoke("Rebuild", 0.5f);
        //_boss.brickGenerator.gameObject.SetActive(false);
        //_boss.brickGenerator.gameObject.SetActive(true);
    }
}
