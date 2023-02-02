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

    //Oyuncu ile arasındaki uzaklığı belirten değer.
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        enemyIsRunning = true;
        canRun = true;
    }

    // FixedUpdate ile daha verimli bir fizik kazandırması.
    void FixedUpdate()
    {
        //Oyuncu ile karakter arası uzaklık hesaplama.
        distance = Vector3.Distance(transform.position, enemyBase._player.transform.position);

        EnemyRun();
        LookAtPlayer();
    }
    
    //Karakterin oyuncuya bakması.
    void LookAtPlayer()
    {
        transform.LookAt(new Vector3(enemyBase._player.transform.position.x,transform.position.y,enemyBase._player.transform.position.z));
    }

    //Karakterin koşmasını kontrol ettikten sonra oyuncuya doğru konşması
    void EnemyRun()
    {
        if(canRun && enemyBase.isGameStart)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, enemyBase._player.transform.position, enemySpeed * Time.deltaTime);
        }
        
    }
    
}
