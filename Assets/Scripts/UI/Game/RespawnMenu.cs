// /**
//  * This file is part of: Pacman
//  * Created: 02.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using F4B1.Core;
using F4B1.Core.Collectable;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI.Game
{
    public class RespawnMenu : MonoBehaviour
    {

        [SerializeField] private IntVariable player1Coins;
        [SerializeField] private IntVariable player2Coins;
        
        [SerializeField] private BoolVariable gameOver;
        [SerializeField] private GameObject respawnMenu;
        [SerializeField] private TextMeshProUGUI text;
        
        [SerializeField] private Sound deathGameOverSound;
        [SerializeField] private Sound coinGameOverSound;
        [SerializeField] private SoundEvent soundEvent;

        private void Awake()
        {
            gameOver.Reset();
        }

        public void Player1LivesChanged(int livesLeft)
        {
            if (livesLeft > 0) return;
            LiveGameOver("PLAYER 1 DIED");

        }
        
        public void Player2LivesChanged(int livesLeft)
        {
            if (livesLeft > 0) return;
            LiveGameOver("PLAYER 2 DIED");
        }

        private void LiveGameOver(string msg)
        {
            soundEvent.Raise(deathGameOverSound);
            respawnMenu.SetActive(true);
            text.text = msg;
            Time.timeScale = 0;
            gameOver.Value = true;
        }

        public void CoinWasCollected()
        {
            var coins = FindObjectsOfType<Coin>();
            if (coins.Length > 1) return;
            
            soundEvent.Raise(coinGameOverSound);
            respawnMenu.SetActive(true);
            text.text = player1Coins.Value > player2Coins.Value ? "PLAYER 1 Won" : "PLAYER 2 Won";
            Time.timeScale = 0;
            gameOver.Value = true;
        }
    }
}