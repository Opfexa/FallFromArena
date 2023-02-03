using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //Base scripte erişmek için değer.
    [SerializeField] EnemyBase enemyBase;
    
    //Karakterin çarpışma esnasında geriye itecek güç değeri.
    [SerializeField] internal float force;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Karakterin çarpması anında animasyon girmesi.
            enemyBase.enemyAnimation.EnemyGetHit();

            //Karakterin çarpma anında geriye savrulması.
            Vector3 dir = transform.position - other.transform.position;
            dir.y = 0;
            enemyBase.enemyRb.AddForce(dir.normalized * force, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Karakterin platformdan düşüp ölmesi.
        if(other.gameObject.name == "DeathZone")
        {
            Debug.Log("Öldün");
            enemyBase.gameManager.score += 100;
            gameObject.SetActive(false);
            enemyBase.isDead = true;
        }
    }
}
