using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Player scriptine erişmek için değer.
    [SerializeField] PlayerBase player;
    //Oyun içinde yaratılacak nesnelere erişmek.
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject ham;
    [SerializeField] GameObject steak;
    //Joystick erişimi.
    [SerializeField] GameObject joystick;
    //UI nesnelerinin değerleri.
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI countDownText;

    //Oyun skorunun tutulduğu değer.
    internal int score;
    //Arenanın çapının değeri.
    public float radius;
    //Oyun başlama değeri.
    internal bool gameStart;
    //Oyunun başlangıcındaki geri sayım.
    internal bool startCountDown;
    //Geri sayım değeri.
    private float countDownValue = 3;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerBase>();
        gameStart = false;
        startCountDown = false;
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if(startCountDown)
        {
            countDownText.text = Mathf.RoundToInt(countDownValue).ToString();
            CountDown();
        }
    }
    
    internal void GameStart()
    {
        //Oyun başladığında UI nesnelerin açılıp kapanması.
        startButton.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        scoreText.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        countDownText.gameObject.SetActive(true);
        //Geri sayımın başlaması için gerekn değer.
        startCountDown = true;
        //Oyunun devam ettirilmesi için gerekn değer.
        Time.timeScale = 1;
        //Nesnelerin oluşturulması için geri sayımın başlatılması.
        StartCoroutine(FoodSpawnTimer());
        StartCoroutine(EnemySpawnTimer());
    }
    //Oyun başlangıcı geri sayımı.
    void CountDown()
    {
        if(countDownValue > 0)
        {
            countDownValue -= Time.deltaTime;
        }
        else if(countDownValue < 0)
        {
            gameStart =true;
            player.isGameStart = true;
            countDownText.gameObject.SetActive(false);
        }
    }
    //Oyunu durdurma sırasında UI nesnelerinin açılıp kapatılması.
    internal void PauseGame()
    {
        pauseButton.SetActive(false);
        startButton.SetActive(true);
        scoreText.gameObject.SetActive(false);
        joystick.SetActive(false);
        pausePanel.SetActive(true);
        countDownText.gameObject.SetActive(false);
        //Oyunun içindeki zamanın durdurulması.
        Time.timeScale = 0;
        
    }
    //Oyundan çıkmak.
    internal void QuitGame()
    {
        Application.Quit();
    }
    //Arenada rasgele bir alan belirlemek.
    private Vector3 RandomPos()
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;
        return randomPos;
    }
    // Rastgele yiyecek oluşturulması.
    private void SpawnFood()
    {
        Instantiate(ham,new Vector3(RandomPos().x,0.2f,RandomPos().y),Quaternion.identity);
        Instantiate(steak,new Vector3(RandomPos().x,0.2f,RandomPos().y),Quaternion.identity);
    }
    // Rastgele düşman oluşturulması.
    private void SpawnEnemy()
    {
        Instantiate(enemy,new Vector3(RandomPos().x,0.2f,RandomPos().y),Quaternion.identity);
    }
    //Arenanın alanını ölçmek için çizilen iki boyutlu çember.
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position,radius);
    }
    //Yiyeceklerin oluşturulması için geri sayım.
    IEnumerator FoodSpawnTimer()
    {
        yield return new WaitForSeconds(5);
        SpawnFood();
        StartCoroutine(FoodSpawnTimer());
    }
    //Düşmanların oluşturulması için geri sayım.
    IEnumerator EnemySpawnTimer()
    {
        yield return new WaitForSeconds(15);
        SpawnEnemy();
        StartCoroutine(EnemySpawnTimer());
    }
}
