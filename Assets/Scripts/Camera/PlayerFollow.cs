using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    //Kameranın takibi için oyuncu nesnesi.
    [SerializeField] private GameObject player;
    //Kamera ile oyuncu arasındaki uzaklık için bir değer.
    [SerializeField] private Vector3 distance;
    //LateUpdate fonksiyonu ile kameranın daha pürüzsüz bir kamera takibi.
    private void LateUpdate() 
    {
        transform.position = player.transform.position + distance;
    }
}
