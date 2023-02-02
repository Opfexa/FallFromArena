using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Base scripte erişmek.
    [SerializeField] PlayerBase playerBase;
    //Koştuğunu bilmek için atanan değer.
    internal bool isRunning;
    // Update is called once per frame
    void Update()
    {
        Animations();
    }

    void Animations()
    {
        //Koşma ve koşmama durumu sırasında animasyonun koşulunu değiştirme.
        if(isRunning)
        {
            playerBase.playerAnim.SetBool("isRunning",true);
        }
        else
        {
            playerBase.playerAnim.SetBool("isRunning",false);
        }
        
    }
    //Hasar alınınca animasyonun devreye girmesi.
    internal void GetHit()
    {
        playerBase.playerAnim.Play("GetHit");
        playerBase.playerAnim.SetBool("isRunning",false);
    }
}
