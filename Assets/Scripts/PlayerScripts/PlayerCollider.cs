using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    //Base script için değer.
    [SerializeField] PlayerBase playerBase;

    //Karakterin çarpışma esnasında geriye itecek güç değeri.
    [SerializeField] internal float force;
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Karakterin çarpması anında animasyon girmesi.
            Debug.Log("Çarptin");
            playerBase.playerAnimation.GetHit();

            //Karakterin çarpma anında geriye savrulması.
            Vector3 dir = transform.position - other.transform.position;
            dir.y = 0;
            playerBase.playerRigid.AddForce(dir.normalized * force, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        //Karakterin platformdan düşüp ölmesi.
        if(other.gameObject.name == "DeathZone")
        {
            Debug.Log("Öldün");
            playerBase.gameManager.LoseGame();
        }

        //Karakterin yiyecekler ile teması.
        if(other.gameObject.tag == "Ham")
        {
            playerBase.playerMovement.SpeedBoost();
        }
        if(other.gameObject.tag == "Steak")
        {
            ForceBoost();
        }
    }
    //Yiyecek güçlendirmesi.
    internal void ForceBoost()
    {
        float oldForce = force;
        force = force + force * 0.5f;
        StartCoroutine(ForceBosstCountDown(oldForce));
    }
    //Boost süresinin geri sayımı.
    IEnumerator ForceBosstCountDown(float oldForce)
    {
        yield return new WaitForSeconds(2);
        force = oldForce;
    }
}
