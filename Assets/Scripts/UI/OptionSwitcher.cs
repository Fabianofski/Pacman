// /**
//  * This file is part of: Pacman
//  * Created: 03.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System;
using Unity.Mathematics;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.UI
{
    public class OptionSwitcher : MonoBehaviour
    {

        [SerializeField] private GameObjectValueList optionList;
        [SerializeField] private IntVariable selectedOption;
        private GameObject currentPreview;

        private void Awake()
        {
            SwitchOption();
        }

        public void NextOption()
        {
            selectedOption.Value = selectedOption.Value < optionList.Count - 1 ? selectedOption.Value + 1 : 0;
            SwitchOption();
        }

        public void PreviousOption()
        {
            selectedOption.Value = selectedOption.Value > 0 ? selectedOption.Value - 1 : optionList.Count - 1;
            SwitchOption();
        }

        private void SwitchOption()
        {
            Destroy(currentPreview);
            currentPreview = Instantiate(optionList.List[selectedOption.Value], transform.position, Quaternion.identity, transform);
        }
    }
}