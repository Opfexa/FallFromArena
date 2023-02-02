using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    //GameManager'a erişmek.
    [SerializeField] GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //Hiyerarşide scripte göre game objeyi arama.
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    //Oyunu başlatma butonu.
    public void StartGame()
    {
        _gameManager.GameStart();
    }
    //Oyunu durdurma butonu.
    public void PauseGame()
    {
        _gameManager.PauseGame();
    }
    //Oyundan çıkış butonu.
    public void QuitGame()
    {
        _gameManager.QuitGame();
    }
}
