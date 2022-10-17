// /**
//  * This file is part of: Pacman
//  * Created: 11.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace F4B1.UI.Game
{
    public class EffectDisplay : MonoBehaviour
    {

        [SerializeField] private List<Effect> effects;
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void OnEffectChange(string effectName)
        {
            var effect = effects.Find(x => x.name == effectName);
            image.sprite = effect?.sprite;
        }
    }

    [Serializable]
    public class Effect
    {
        public string name;
        public Sprite sprite;
    }
}