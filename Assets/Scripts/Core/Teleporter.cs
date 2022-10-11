// /**
//  * This file is part of: Pacman
//  * Created: 11.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityEngine;

namespace F4B1.Core
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Vector2 teleportTo;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.transform.position = teleportTo;
        }
    }
}