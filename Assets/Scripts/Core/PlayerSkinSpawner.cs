// /**
//  * This file is part of: Pacman
//  * Created: 11.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class PlayerSkinSpawner : MonoBehaviour
    {
        
        [SerializeField] private GameObjectValueList optionList;
        [SerializeField] private IntVariable selectedOption;
        [SerializeField] private GameObject previewSkin;

        private void Awake()
        {
            Destroy(previewSkin);
            Instantiate(optionList.List[selectedOption.Value], transform.position, Quaternion.identity, transform);
        }
    }
}