// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Amelia Witon
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Collectable
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int score;
        [SerializeField] private Sound munchSound;
        [SerializeField] private SoundEvent soundEvent;
        
        private bool coinCollected;
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player") || coinCollected) return;
            soundEvent.Raise(munchSound);
            coinCollected = true;
            col.GetComponent<Score>().CoinCollected(score);
            Destroy(gameObject);
        }
    }
}
