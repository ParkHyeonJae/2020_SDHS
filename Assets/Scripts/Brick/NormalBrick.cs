using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NormalBrick : Brick
{
    protected override void DestroyAction()
    {
        base.DestroyAction();

        SoundManager.Instance.PlayOneShot("BreakBlock");
    }
}
