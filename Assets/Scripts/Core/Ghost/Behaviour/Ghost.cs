// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using F4B1.Core.Collectable;
using F4B1.Core.Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Ghost.Behaviour
{
    public abstract class Ghost : MonoBehaviour
    {
        private GameObject[] players;
        [SerializeField] private Transform spawn;
        [SerializeField] protected Transform destination;
        [SerializeField] protected Transform scatterPos;
        [SerializeField] private Vector2 houseExitPos;
        [SerializeField] private int leaveHouseTime;
        private GhostPathfinder pathfinder;
        [SerializeField] public string ghostState = "HOUSE";
        [SerializeField] private StringVariable globalGhostState;
        [SerializeField] private GameObject ghostDieEffect;
        [SerializeField] private Sound dieSound;
        [SerializeField] private SoundEvent soundEvent;
        
        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            pathfinder = GetComponent<GhostPathfinder>();
            Invoke(nameof(LeaveHouse), leaveHouseTime);
        }

        protected virtual void Update()
        {
            pathfinder.randomHeuristic = GhostIsFrightened();
            switch (ghostState)
            {
                case "LEAVE_HOUSE":
                {
                    destination.position = houseExitPos;
                    if(RoundVector(transform.position) == houseExitPos)
                        ghostState =  globalGhostState.Value;
                    break;
                }
                case "SCATTER":
                    destination.position = scatterPos.position;
                    break;
            }
        }

        public bool GhostIsFrightened()
        {
            var playerHasPowerPellet = GetNearestPlayer().GetComponent<PlayerMovement>().PowerPellet;
            var frightened = playerHasPowerPellet && ghostState is "SCATTER" or "CHASE";
            return frightened;
        }

        private Vector2 RoundVector(Vector2 vector)
        {
            return new Vector2(Mathf.Round(vector.x * 10)/10, Mathf.Round(vector.y * 10)/10);
        }

        protected GameObject GetNearestPlayer()
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
            if (!col.CompareTag("Player") || ghostState == "DEAD") return;

            if (col.GetComponent<PlayerMovement>().PowerPellet)
                Die(col.gameObject);
            else
                col.GetComponent<Health>().Hit();
        }

        private void Die(GameObject player)
        {
            ghostState = "DEAD";
            pathfinder.speedModifier = 2;
            soundEvent.Raise(dieSound);
            pathfinder.randomHeuristic = false;
            destination.position = spawn.position;
            player.GetComponent<Score>().CoinCollected(200);
            var score = Instantiate(ghostDieEffect, transform.position, Quaternion.identity);
            Destroy(score, .5f);
            LeanTween.value(player, 1, 0.2f, .5f).setOnUpdate((val) => Time.timeScale = val
            ).setOnComplete(() => Time.timeScale = 1).setIgnoreTimeScale(true);
        }

        public void DoRespawn()
        {            
            pathfinder.speedModifier = 1;
            Invoke(nameof(Respawn), 1f);
        }

        private void Respawn()
        {
            ghostState = "LEAVE_HOUSE";
        }

        public void GlobalGhostStateChanged(string state)
        {
            if (ghostState is "SCATTER" or "CHASE") 
                ghostState = state;
        }

        public void LeaveHouse()
        {
            pathfinder.inHouse = false;
            ghostState = "LEAVE_HOUSE";
        }
    }
}