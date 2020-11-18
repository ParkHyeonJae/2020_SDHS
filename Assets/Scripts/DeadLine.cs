using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField] PlayerHpPointBar playerHp = null;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Ball"))
        {
            Debug.Assert(playerHp != null, "NullReference");
            Boss boss = FindObjectOfType<Boss>();
            boss.ballPool.reset();
            boss.SpawnBall();
            CameraShake.OnShake(0.5f, 1.0f);
            PlayerHpPointBar.OnAddPoint(-1);
            //playerHp.AddPoint(-1);
            //if (playerHp.IsDead())
            //{
            //    //GameSystem.Instance.OnGameOver?.Invoke();
            //}
        }
    }
}
