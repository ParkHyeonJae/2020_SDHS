using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BossBrick : Brick
{
    protected override void DestroyAction()
    {
        //base.DestroyAction();

        Destroy(this.gameObject);
    }
}
