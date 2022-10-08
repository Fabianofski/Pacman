// /**
//  * This file is part of: Pacman
//  * Created: 08.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityEngine;

namespace F4B1.Core.Ghost
{
    public class GhostRespawner : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Ghost")) return;

            col.GetComponent<Ghost>().DoRespawn();
        }
    }
}