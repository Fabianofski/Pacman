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
        [SerializeField] private Transform scatterPos;
        [SerializeField] private Vector2 houseExitPos;
        [SerializeField] private int leaveHouseTime;
        protected GhostPathfinder pathfinder;
        protected bool dead;
        private bool frightened;
        private bool scatter;
        [SerializeField] private bool leaveHouse;
        
        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            pathfinder = GetComponent<GhostPathfinder>();
            Invoke(nameof(LeaveHouse), leaveHouseTime);
        }

        protected virtual void Update()
        {
            frightened = GetNearestPlayer().GetComponent<PlayerMovement>().PowerPellet;
            pathfinder.randomHeuristic = frightened && !pathfinder.inHouse && !dead;
            if (leaveHouse)
            {
                destination.position = houseExitPos;
                leaveHouse = RoundVector(transform.position) != houseExitPos;
            }
            else if (scatter)
                destination.position = scatterPos.position;
        }

        private Vector2 RoundVector(Vector2 vector)
        {
            return new Vector2(Mathf.Round(vector.x * 10)/10, Mathf.Round(vector.y * 10)/10);
        }

        private GameObject GetNearestPlayer()
        {
            var closestDistance = Mathf.Infinity;
            GameObject nearestPlayer = null;
            foreach (var player in players)
            {
                var playerDistance = Vector2.Distance(transform.position, player.transform.position);
                if (!(playerDistance < closestDistance)) continue;
                closestDistance = playerDistance;
                nearestPlayer = player;
            }

            return nearestPlayer;
        }
        
        protected Vector2 GetNearestPlayerPosition()
        {
            return GetNearestPlayer().transform.position;
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
            pathfinder.randomHeuristic = false;
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

        public void Scatter(bool value)
        {
            scatter = value;
        }

        public void LeaveHouse()
        {
            pathfinder.inHouse = false;
            leaveHouse = true;
        }
    }
}