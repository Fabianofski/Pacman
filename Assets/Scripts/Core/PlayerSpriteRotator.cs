// /**
//  * This file is part of: Pacman
//  * Created: 11.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using TreeEditor;
using UnityEngine;

namespace F4B1.Core
{
    public class PlayerSpriteRotator : MonoBehaviour
    {

        private PlayerMovement playerMovement;
        
        private void Awake()
        {
            playerMovement = transform.parent.GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (!playerMovement) return;
            
            var dir = playerMovement.Input;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}