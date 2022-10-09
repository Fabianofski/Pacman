// /**
//  * This file is part of: Pacman
//  * Created: 02.10.2022
//  * Copyright (C) 2022 Niklas Lischke
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Item : MonoBehaviour
    {

        [SerializeField] private GameObjectEvent itemEvent;
        private bool itemUsed;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || itemUsed) return;

            itemUsed = true;
            itemEvent.Raise(collision.gameObject);
        }

    }
}
