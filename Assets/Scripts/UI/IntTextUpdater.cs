// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using TMPro;
using UnityEngine;

namespace F4B1.UI
{
    public class IntTextUpdater : MonoBehaviour
    {

        [SerializeField] private string prefix;
        [SerializeField] private string suffix;
        [SerializeField] private TextMeshProUGUI text;
        
        public void UpdateText(int value)
        {
            text.text = prefix + value + suffix;
        }
    }
}