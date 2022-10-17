// /**
//  * This file is part of: Pacman
//  * Created: 09.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using System.Collections.Generic;
using System.Linq;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace F4B1.Core.Ghost
{
    public class GhostPathfinder : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        [SerializeField] private int speed;
        public float SpeedModifier = 1;
        public bool randomHeuristic;
        public bool inHouse = true;
        
        private Rigidbody2D rb2d;
        private int wallLayer;
        private int intersectionLayer;
        private int houseBorderLayer;
        
        private readonly Vector2[] directions = new[] { Vector2.down, Vector2.up, Vector2.left, Vector2.right };
        public Vector2 currentDir = Vector2.up;
        private bool justMadeDecision;
        
        [SerializeField] private SoundEvent soundEvent;
        [SerializeField] private Sound turnSound;
        
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            wallLayer = LayerMask.GetMask("Tilemap");
            intersectionLayer = LayerMask.GetMask("Intersection");
            houseBorderLayer = LayerMask.GetMask("House");
        }

        public void ReverseDirection()
        {
            currentDir = -currentDir;
        }
        
        private void FixedUpdate()
        {
            rb2d.velocity = currentDir * (speed * SpeedModifier);
            if (IsAtIntersection())
                MakeTurn();
        }

        private bool IsAtIntersection()
        {
            if (Physics2D.Raycast(transform.position, rb2d.velocity, .5f, wallLayer))
                return true;
            
            if (!Physics2D.Raycast(transform.position, rb2d.velocity, .01f, intersectionLayer))
                return false;
            
            var possibleDir = 0;
            foreach (var dir in directions)
            {
                if (!Physics2D.BoxCast(GetSnappedPosition() + dir, Vector2.one * .9f, 0, dir, 0, wallLayer))
                {
                    possibleDir++;
                }
            }
            return possibleDir >= 3;
        }
        
        private void MakeTurn()
        {
            if (justMadeDecision) return;
            
            soundEvent.Raise(turnSound);
            
            var snappedPosition = GetSnappedPosition();
            var nextDir = randomHeuristic ? GetRandomTile(snappedPosition) : GetClosestTile(snappedPosition);

            if (currentDir == nextDir) return;
            
            rb2d.velocity = Vector2.zero;
            transform.position = snappedPosition;
            currentDir = nextDir;
            justMadeDecision = true;
            Invoke(nameof(ResetJustMadeDecision), .1f);
        }

        private Vector2 GetClosestTile(Vector2 snappedPosition)
        {
            var nextDir = currentDir;
            var minDistanceToTarget = Mathf.Infinity;

            foreach (var dir in directions)
            {
                if (dir == -currentDir) continue; // Pacman can't reverse direction
                if (Physics2D.Raycast(snappedPosition, dir, 1f, wallLayer))
                    continue;
                if (Physics2D.Raycast(snappedPosition, dir, 1f, houseBorderLayer) && inHouse)
                    continue;

                var targetTile = snappedPosition + dir;
                var distance = Vector2.Distance(targetTile, destination.position);
                if (minDistanceToTarget < distance) continue;
                minDistanceToTarget = distance;
                nextDir = dir;
            }

            return nextDir;
        }
        
        private Vector2 GetRandomTile(Vector2 snappedPosition)
        {
            var possibleDirections = new List<Vector2>();

            foreach (var dir in directions)
            {
                if (dir == -currentDir) continue; // Pacman can't reverse direction
                if (Physics2D.Raycast(snappedPosition, dir, 1f, wallLayer))
                    continue;
                if (Physics2D.Raycast(snappedPosition, dir, 1f, houseBorderLayer) && inHouse)
                    continue;
                possibleDirections.Add(dir);
            }

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }

        private void ResetJustMadeDecision()
        {
            justMadeDecision = false;
        }

        private Vector2 GetSnappedPosition()
        {
            var pos = transform.position;
            pos = new Vector2(Mathf.Round(pos.x * 10)/10, Mathf.Round(pos.y*10)/10);
            return pos;
        }
    }
}