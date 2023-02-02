using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    //Base scripte erişmek için bir script nesnesi.
    [SerializeField] EnemyBase enemyBase;
    // Update is called once per frame
    void Update()
    {
        EnemyRun();
    }
    //Düşmanın fiziksel koşması ile birlikte animasyon koşulunu değiştirme.
    void EnemyRun()
    {
        if(enemyBase.enemyMovement.enemyIsRunning)
        {
            enemyBase.enemyAnim.SetBool("enemy_Run",true);
        }
    }
    //Düşman hasar aldığında hasar alma animasyonunun oynatılması.
    internal void EnemyGetHit()
    {
        enemyBase.enemyAnim.Play("Enemy_GetHit");
    }
}
