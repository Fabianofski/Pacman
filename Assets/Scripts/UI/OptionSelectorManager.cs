// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace F4B1.UI
{
    public class OptionSelectorManager : MonoBehaviour
    {

        [SerializeField] private IntVariable selectedMap;
        
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + selectedMap.Value + 1);
        }
        
    }
}