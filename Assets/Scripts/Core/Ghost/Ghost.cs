// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core.Ghost
{
    public abstract class Ghost : MonoBehaviour
    {
        private GameObject[] players;

        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        protected Vector2 FindNearestPlayer()
        {
            var closestDistance = Mathf.Infinity;
            var nearestPlayer = new Vector2();
            foreach (var player in players)
            {
                var playerDistance = Vector2.Distance(transform.position, player.transform.position);
                if (!(playerDistance < closestDistance)) continue;
                closestDistance = playerDistance;
                nearestPlayer = player.transform.position;
            }

            return nearestPlayer;
        }
    }
}