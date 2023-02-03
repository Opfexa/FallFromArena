using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    //Karaktere erişmesi için değer.
    public PlayerBase _player;
    private void Awake() 
    {
        //Oluşturulduktan sonra geri sayım.
        StartCoroutine(DestorTimer());
    }
    private void OnTriggerEnter(Collider other) 
    {
        //Oyuncuya değdiklerinde yok olmaları.
        if(other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }    
    }
    //Yok olmaları için geri sayım.
    IEnumerator DestorTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
