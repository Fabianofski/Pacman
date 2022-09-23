// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/
using UnityEngine;
using UnityEngine.InputSystem;

namespace F4B1.Core
{
    public class PlayerMovement : MonoBehaviour
    {

        private Vector2 input;
        [SerializeField] private InputAction moveInputAction;

        private void OnEnable()
        {
            moveInputAction.Enable();
        }

        private void OnDisable()
        {
            moveInputAction.Disable();
        }

        public void Update()
        {
            input = moveInputAction.ReadValue<Vector2>();
            // moveInputAction wird im Inspector definiert (schau es dir mal bei Player1 und Player2 an)
            // Input ist ein Vector2 mit einer X und Y Achse
            // (gespeichert in input.x oder input.y)
            // Wenn A gedrückt wird ist X = -1, Wenn D gedrückt wird ist X = 1, sonst X = 0
            // Wenn W gedrückt wird ist Y = 1, Wenn S gedrückt wird ist Y = -1, sonst Y = 0
            // Wenn z.B. W und D gleichzeitig gedrückt wird ist X = 0.75 und Y = 0.75
            // Das passiert weil man sich sonst schräg zu schnell bewegen würde wenn X und Y = 1 wären
            // Ist ja aber irrelevant für uns da wir uns nicht schräg bewegen können
            
            // VVVV Kannst es hier mal ausprobieren einfach auskommentieren und WASD oder die Pfeiltasten verwenden
            // Kommentar danach bitte löschen
            // Debug.Log(gameobject.name + " " + input);
        }
    }
}
