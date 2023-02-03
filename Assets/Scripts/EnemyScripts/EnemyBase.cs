using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu scriptin ait olduğu nesneyi bileşenlere zorunlu hale getirmek.
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyBase : MonoBehaviour
{
    //Bileşenleri çağırmak.
    internal Rigidbody enemyRb;
    internal Animator enemyAnim;

    //Karakterin diğer scriptlerini erişim için çağırmak.
    [SerializeField] internal EnemyMovement enemyMovement;
    [SerializeField] internal EnemyAnimation enemyAnimation;
    [SerializeField] internal EnemyCollision enemyCollision;

    //Oyunun managerine erişmek için çağırma.
    [SerializeField] internal GameManager gameManager;

    //Düşmanın oyuncular için liste.
    [SerializeField] internal List<GameObject> enemys;
    
    //Oyunun başladığını test etmek için bir değer.
    internal bool isGameStart;
    //Karakterin ölümü için değer.
    internal bool isDead;
    private void Awake() 
    {
        //GameManager objesini bulmak için scripti ile hiyerarşide arama.
        gameManager = GameObject.FindObjectOfType<GameManager>();

        //Bileşenlere erişmek
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    void Start()
    {
       isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGameStart = gameManager.gameStart;
    }
}
