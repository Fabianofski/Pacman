// /**
//  * This file is part of: Pacman
//  * Created: 17.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using System.Collections.Generic;
using F4B1.Core;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI.Lobby
{
    public class DifficultySwitcher : MonoBehaviour
    {

        [SerializeField] private List<DifficultySetting> difficultySettings;
        [SerializeField] private IntVariable currentSetting;
        [SerializeField] private TextMeshProUGUI difficultyText;
        [SerializeField] private TextMeshProUGUI caption;
        [SerializeField] private FloatVariable ghostSpeed;
        [SerializeField] private FloatVariable playerSpeed;
        [SerializeField] private FloatVariable itemEffectDuration;
        
        
        private void Awake()
        {
            ChangePreviewText();
        }

        public void NextOption()
        {
            currentSetting.Value = currentSetting.Value < difficultySettings.Count - 1 ? currentSetting.Value + 1 : 0;
            ChangePreviewText();
        }

        public void PreviousOption()
        {
            currentSetting.Value = currentSetting.Value > 0 ? currentSetting.Value - 1 : difficultySettings.Count - 1;
            ChangePreviewText();
        }
        
        private void ChangePreviewText()
        {
            var setting = difficultySettings[currentSetting.Value];

            ghostSpeed.Value = setting.ghostSpeed;
            playerSpeed.Value = setting.playerSpeed;
            itemEffectDuration.Value = setting.itemEffectDuration;

            caption.text = setting.name;
            difficultyText.text = 
                $"Ghost Speed:          {setting.ghostSpeed}\n" +
                $"Player Speed:         {setting.playerSpeed}\n" +
                $"Item Effect Duration: {setting.itemEffectDuration}\n" +
                $"Number of Ghosts:     {setting.numberOfGhost}";

        }
    }
}