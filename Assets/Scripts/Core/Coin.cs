// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Amelia Witon
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int score;
        private bool coinCollected;
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player") || coinCollected) return;
            coinCollected = true;
            col.GetComponent<Score>().CoinCollected(score);
            Destroy(gameObject);
        }
    }
}
