// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace F4B1.UI.Generic
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private BoolVariable pauseToggled;
        [SerializeField] private InputAction pauseInputAction;
        [SerializeField] private List<AtomBaseVariable> resetAtoms;

        public BoolVariable PauseToggled
        {
            set => pauseToggled = value;
        }

        private void Awake()
        {
            pauseInputAction.performed += OnPause;
        }

        private void OnEnable()
        {
            pauseInputAction.Enable();
        }

        private void OnDisable()
        {
            pauseInputAction.Disable();
        }

        private void OnPause(InputAction.CallbackContext ctx)
        {
            pauseToggled.Value = !pauseToggled.Value;
            Time.timeScale = pauseToggled.Value ? 0 : 1;
        }

        public void UnPause()
        {
            Time.timeScale = pauseToggled.Value ? 0 : 1;
        }

        public void LoadNextScene()
        {
            ResetAtoms();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMenuScene()
        {
            ResetAtoms();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void ReloadCurrentScene()
        {
            ResetAtoms();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        private void ResetAtoms()
        {
            foreach (var atom in resetAtoms) atom.Reset();
        }
    }
}