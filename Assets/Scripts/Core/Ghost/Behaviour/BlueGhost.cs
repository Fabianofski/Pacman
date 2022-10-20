// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core.Ghost.Behaviour
{
    public class BlueGhost : Ghost
    {

        private Transform redGhost;
        private Vector2 inFrontPlayer;
        
        private void Start()
        {
            redGhost = FindObjectOfType<RedGhost>().transform;
        }

        protected override void Update()
        {
            if (ghostState is "DEAD") return;

            var nearestPlayer = GetNearestPlayer();
            var playerDirection = nearestPlayer.GetComponent<Rigidbody2D>().velocity.normalized;
            inFrontPlayer = (Vector2) nearestPlayer.transform.position + playerDirection * 2;
            
            destination.position = inFrontPlayer + ((inFrontPlayer - (Vector2)redGhost.position));

            base.Update();
        }

        private void OnDrawGizmos()
        {
            if (!redGhost) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(redGhost.position, inFrontPlayer);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(inFrontPlayer, destination.position);
        }
    }
}