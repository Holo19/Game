using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _colletCoinEffect;

    private int _coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.ColletCoin(_coinValue);

            _colletCoinEffect.transform.position = transform.position;
            _colletCoinEffect.Play();

            gameObject.SetActive(false);
        }
        
    }
}
