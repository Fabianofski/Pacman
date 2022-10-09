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
    public abstract class Ghost : MonoBehaviour
    {
        private GameObject[] players;
        [SerializeField] private Transform spawn;
        [SerializeField] protected Transform destination;
        protected bool dead;
        protected GhostPathfinder pathfinder;
        
        protected virtual void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            pathfinder = GetComponent<GhostPathfinder>();
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;

            if (col.GetComponent<PlayerMovement>().PowerPellet)
                Die();
            else
                col.GetComponent<Health>().Hit();
        }

        private void Die()
        {
            dead = true;
            destination.position = spawn.position;
        }

        public void DoRespawn()
        {
            Invoke(nameof(Respawn), 1f);
        }

        private void Respawn()
        {
            dead = false;
        }
    }
}