// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Amelia Witon
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Score : MonoBehaviour
    {

        [SerializeField] private IntVariable score;


        private void Awake()
        {
            score.Reset();
        }
        public void CoinCollected(int i)
        {
            score.Value += i;
        }
    }
}
