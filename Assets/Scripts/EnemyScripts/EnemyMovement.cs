using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Base script erişimi.
    [SerializeField] EnemyBase enemyBase;

    //Karakterin hızı.
    [SerializeField] float enemySpeed;

    //Koştuğunu belirten değer.
    internal bool enemyIsRunning;

    //Koşabilme durumunu belirten değer.
    internal bool canRun;

    // Start is called before the first frame update
    void Start()
    {
        enemyIsRunning = true;
        canRun = true;
    }

    // FixedUpdate ile daha verimli bir fizik kazandırması.
    void FixedUpdate()
    {
        if(enemyBase.isGameStart)
        {
            EnemyRun();
            LookAtPlayer();
        }
        
    }
    
    //Karakterin oyuncuya bakması.
    void LookAtPlayer()
    {
        transform.LookAt(new Vector3(FindClosestEnemy().transform.position.x,transform.position.y,FindClosestEnemy().transform.position.z));
    }

    //Karakterin koşmasını kontrol ettikten sonra oyuncuya doğru konşması
    void EnemyRun()
    {
        if(canRun)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, FindClosestEnemy().transform.position, enemySpeed * Time.deltaTime);
        }
    }
    //En yakındaki düşmanı bulma.
    public GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemyBase.enemys)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                if(closest.name != "Player" && closest.GetComponent<EnemyBase>().isDead)
                {
                    enemyBase.enemys.Remove(closest);
                }
            }
        }
        return closest;
    }
    
}
