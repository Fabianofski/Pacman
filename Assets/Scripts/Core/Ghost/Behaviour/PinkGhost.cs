// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core.Ghost.Behaviour
{
    public class PinkGhost : Ghost
    {
        
		private Vector2 targetTile;
		
        protected override void Update()
        {
            if (ghostState is "DEAD") return;

            var nearestPlayer = GetNearestPlayer();
			var playerDirection = nearestPlayer.GetComponent<Rigidbody2D>().velocity.normalized;
			targetTile = (Vector2) nearestPlayer.transform.position + playerDirection * 4;
			
			
            destination.position = targetTile;
            
            base.Update();
        }
    }
}