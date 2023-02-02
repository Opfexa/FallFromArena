using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Base scripte erişmek.
    [SerializeField] PlayerBase playerBase;
    //Karakterin hızı.
    [SerializeField] internal float speed;
    //Karakterin hareket edebilirliğini gösteren değer.
    internal bool canMove;

    private void Start() 
    {
        canMove = true;
    }
    void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        PlayerRun();
        PlayerRotation();
    }
    //Oyunun başlması ile joystick yardımı ile hareket etmesini sağlamak.
    private void PlayerRun()
    {
        if(playerBase.isGameStart && canMove)
        {
            playerBase.playerRigid.velocity = new Vector3(playerBase.joystick.Horizontal * speed, playerBase.playerRigid.velocity.y, playerBase.joystick.Vertical * speed);
        }
    }
    //Karakterin joystickleri ile döndürülmesini sağlama.
    private void PlayerRotation()
    {
        if(playerBase.joystick.Horizontal != 0  && canMove|| playerBase.joystick.Vertical != 0 && canMove)
        {
            transform.rotation = Quaternion.LookRotation(playerBase.playerRigid.velocity);
            playerBase.playerAnimation.isRunning = true;
        }
        else
        {
            playerBase.playerAnimation.isRunning = false;
        }
    }
    //Yiyecek ile hız güçlendirmesi.
    internal void SpeedBoost()
    {
        float oldSpeed = speed;
        speed = speed + speed * 0.5f;
        StartCoroutine(SpeedBoostCountDown(oldSpeed));
    }
    //Güçlendirmenin geri sayımı.
    IEnumerator SpeedBoostCountDown(float oldSpeed)
    {
        yield return new WaitForSeconds(2);
        speed = oldSpeed;
    }
}
