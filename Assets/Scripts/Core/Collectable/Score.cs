// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Amelia Witon
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Core.Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Collectable
{
    public class Score : MonoBehaviour
    {

        [SerializeField] private IntVariable score;
        private PlayerMovement playerMovement;
        
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            score.Reset();
        }
        public void CoinCollected(int i)
        {
            score.Value += playerMovement.DoubleScore ? 2 * i : i;
        }
    }
}
