// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityEngine;

namespace F4B1.Core.Ghost
{
    public class OrangeGhost : Ghost
    {
        protected override void Update()
        {
            if (ghostState is "DEAD") return;

            var nearestPlayer = GetNearestPlayerPosition();
            destination.position = nearestPlayer;
            pathfinder.randomHeuristic = Vector2.Distance(transform.position, nearestPlayer) < 8;
            
            base.Update();
        }
        
        
    }
}