using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    private Move _move;

    private bool _isAlive;
    public bool IsAlive => _isAlive;

    private Vector3 _startPosition;

    private int _collectedCoins;
    public int CollectedCoins => _collectedCoins;

    private void Awake()
    {
        _move = GetComponent<Move>();
        _startPosition = transform.position;
    }
    private void Update()
    {
        if (_isAlive == false)
            gameObject.SetActive(false);
    }
    public void ColletCoin(int value) => _collectedCoins += value;
    public void Kill() => _isAlive = false;
    public void NewGame()
    {
        _move.ResetPhysics();

       gameObject.SetActive(true);
       transform.position = _startPosition;

       _collectedCoins = 0;
       _isAlive = true;
    }
    private void OnDisable()
    {
        _deathEffect.transform.position = transform.position;
        _deathEffect.Play();
    }
}
