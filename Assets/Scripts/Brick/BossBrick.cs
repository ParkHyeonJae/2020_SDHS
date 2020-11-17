using UnityEngine;

public sealed class BossBrick : Brick
{
    protected override void DestroyAction()
    {
        Debug.Log("==== BOSS DAMAGE ! ====");
        Boss _boss = FindObjectOfType<Boss>();
        _boss.InitCoolTime();
        _boss.TakeDamage(1);
        Destroy(this.gameObject);
        CameraShake.OnShake(0.5f, 0.1f);
        _boss.brickGenerator.Invoke("Rebuild", 0.5f);
    }
}
