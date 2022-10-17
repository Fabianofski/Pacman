// /**
//  * This file is part of: Pacman
//  * Created: 06.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;
using UnityEngine.UI;

namespace F4B1.UI.Game
{
    public class HealthUIUpdater : MonoBehaviour
    {
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void UpdateImage(int health)
        {
            image.fillAmount = health / 3f;
        }
    }
}