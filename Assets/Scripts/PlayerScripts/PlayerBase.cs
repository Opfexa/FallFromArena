using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu scriptin ait olduğu nesneyi bileşenlere zorunlu hale getirmek.
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerBase : MonoBehaviour
{
    //Diğer scriptlere erişimi kolaylaştırmak için çağırma.
    [SerializeField] internal PlayerMovement playerMovement;
    [SerializeField] internal PlayerAnimation playerAnimation;
    [SerializeField] internal PlayerCollider playerCollider;
    
    //Joystick' e erişim.
    [SerializeField] internal FixedJoystick joystick;
    [SerializeField] internal GameManager gameManager;

    //Zorunlu bileşenlerin değeri.
    internal Rigidbody playerRigid;
    internal Animator playerAnim;

    //Oyunun başlama durumunu gösteren değer.
    [SerializeField] internal bool isGameStart;

    //Bileşenlere erişmek
    private void Awake() 
    {
        playerRigid = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }
    void Start()
    {
       isGameStart = false;
       gameManager = GameObject.FindObjectOfType<GameManager>();
    }
}
