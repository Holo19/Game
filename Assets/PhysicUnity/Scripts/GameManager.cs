using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _necessaryCountCoin;
    
    [SerializeField] private float _timeToLose;
    
    [SerializeField] private Player _player;

    [SerializeField] private List<GameObject> _coins;

    [SerializeField] private TMP_Text _gameMessage;

    private KeyCode _restartKey = KeyCode.R;

    private bool _isActive;

    private float _time = 0;
    private int _previousTimeValue = 0;

    private string _winMassage = "Вы победили";
    private string _looseMassage = "Вы проиграли";


    private void Start()
    {
        _isActive = true;
        StartGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(_restartKey))
            StartGame();

        if (_isActive == false)
            return;

        Timer();

        if (_player.CollectedCoins >= _necessaryCountCoin)
        {
            WinTheGame();
            _isActive = false;
        }
          
        if (_time >= _timeToLose || _player.IsAlive == false)
        {
            GameOver();
            _isActive = false;
        }
    }
    private void Timer()
    {
        int currentTime;

       _time += Time.deltaTime;
        currentTime = (int)Math.Round(_time);

        if (currentTime != _previousTimeValue)
        {
            Debug.Log(currentTime);
            _previousTimeValue = currentTime;
        }
    }
    private void StartGame()
    {
        _isActive = true;
        _player.NewGame();
        ActivateCoins();
        _time = 0;
        _gameMessage.gameObject.SetActive(false);
    }
    private void GameOver()
    {
        _isActive = false;
        _player.Kill();
        Debug.Log(_looseMassage);
        ShowMessage(_looseMassage + "\nНажмите R, чтобы начать заново");
    }
    private void WinTheGame()
    {
        _isActive = false;
        Debug.Log(_winMassage);
        ShowMessage(_winMassage + "\nНажмите R, чтобы начать заново");
    }
    private void ActivateCoins()
    {
        foreach (GameObject coin in _coins)
            coin.SetActive(true);
    }
    private void ShowMessage(string message)
    {
        _gameMessage.text = message;
        _gameMessage.gameObject.SetActive(true);
    }
}
