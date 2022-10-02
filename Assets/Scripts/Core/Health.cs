// /**
//  * This file is part of: Pacman
//  * Created: 02.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Health : MonoBehaviour
    {

        [SerializeField] private IntVariable life;
        private bool invincible;
        
        private void Awake()
        {
            life.Reset();
        }

        public void Hit()
        {
            if (invincible) return;
            life.Value--;
            invincible = true;
            Invoke(nameof(ResetInvincibility), 1f);
        }

        private void ResetInvincibility()
        {
            invincible = false;
        }
    }
}