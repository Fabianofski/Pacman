// /**
//  * This file is part of: Pacman
//  * Created: 17.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "new Difficulty Setting", order = 0)]
    public class DifficultySetting : ScriptableObject
    {
        [Range(2,10)] public int ghostSpeed;
        [Range(2,10)] public int playerSpeed;
        [Range(3,10)] public int itemEffectDuration;
        [Range(4,8)]  public int numberOfGhost = 4;
    }
}