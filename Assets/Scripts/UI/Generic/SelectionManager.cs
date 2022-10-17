// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace F4B1.UI.Generic
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private GameObject firstSelected;
        private EventSystem _eventSystem;
        [SerializeField] private InputAction onNavigateAction;
        [SerializeField] private InputAction onMouseMoveAction;

        public GameObject FirstSelected
        {
            set => firstSelected = value;
        }

        private GameObject LastSelectedGameObject { get; set; }

        private void OnEnable()
        {
            onNavigateAction.Enable();
            onMouseMoveAction.Enable();

            onNavigateAction.performed += _ => OnNavigate();
            onMouseMoveAction.performed += _ => OnMouseMove();
        }

        private void OnDisable()
        {
            onNavigateAction.Disable();
            onMouseMoveAction.Disable();
        }
        
        private void Start()
        {
            _eventSystem = FindObjectOfType<EventSystem>();
            LastSelectedGameObject = firstSelected;
        }

        private void OnNavigate()
        {
            if (_eventSystem.currentSelectedGameObject != null) return;
            _eventSystem.SetSelectedGameObject(LastSelectedGameObject);
        }

        private void OnMouseMove()
        {
            if (_eventSystem.currentSelectedGameObject == null) return;
            LastSelectedGameObject = _eventSystem.currentSelectedGameObject;
        }
    }
}