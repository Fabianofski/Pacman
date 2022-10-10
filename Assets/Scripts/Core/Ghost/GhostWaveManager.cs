// /**
//  * This file is part of: Pacman
//  * Created: 10.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Ghost
{
    public class GhostWaveManager : MonoBehaviour
    {
        [SerializeField] private StringVariable globalGhostState;
        [SerializeField] private List<Mode> modeDurations;
        private int currentIndex;

        private void Awake()
        {
            StartNextWave();
        }

        private void StartNextWave()
        {
            Mode mode = modeDurations[currentIndex];
            
            globalGhostState.Value = mode.name;
            currentIndex++;
            if (mode.duration == -1) return;
            Invoke(nameof(StartNextWave), mode.duration);
        }
    }

    [Serializable]
    public class Mode
    {
        public string name;
        public int duration;
    }
}