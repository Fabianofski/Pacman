// /**
//  * This file is part of: Pacman
//  * Created: 26.09.2022
//  * Copyright (C) 2022 Niklas Lischke
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;
using UnityEngine.InputSystem;
using UnityAtoms.BaseAtoms;

namespace F4B1.Core
{

[RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        private const float MoveSpeed = 5f;
        private Vector2 input;
        [SerializeField] private StringVariable itemMoveEffect;
        public bool PowerPellet { get; private set; }
        private bool pressed;
        public bool DoubleScore { get; private set; }
        
        [SerializeField] private InputAction moveInputAction;

        private void Awake()
        {
            this.rb2d = GetComponent<Rigidbody2D>();
            moveInputAction.performed += _ => pressed = true;
            moveInputAction.canceled += _ => pressed = false;
        }

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
            if (!pressed) return;
            input = moveInputAction.ReadValue<Vector2>();
        }

        public void FixedUpdate()
        {
            DoubleScore = itemMoveEffect.Value == "double";
            PowerPellet = itemMoveEffect.Value == "power";
            
            switch(itemMoveEffect.Value)
            {
                case "normal":
                    rb2d.velocity = input * MoveSpeed;
                    break;
                case "inverted":
                    rb2d.velocity = input * -MoveSpeed;
                    break;
                case "frozen":
                    rb2d.velocity = Vector2.zero;
                    break;
                case "fast":
                    rb2d.velocity = input * 10f;
                    break;
                case "slow":
                    rb2d.velocity = input * 2f;
                    break;
            }           
        }

        public void InvertControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("invert " + gameObject.name);
            itemMoveEffect.Value = "inverted";
            Invoke(nameof(ResetControls), 3f);
        }

        public void FreezeControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("freeze " + gameObject.name);
            itemMoveEffect.Value = "frozen";
            Invoke(nameof(ResetControls), 3f);
        }

        public void SlowControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("slow " + gameObject.name);
            itemMoveEffect.Value = "slow";
            Invoke(nameof(ResetControls), 3f);
        }

        public void FastControls(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("fast " + gameObject.name);
            itemMoveEffect.Value = "fast";
            Invoke(nameof(ResetControls), 3f);
        }

        public void Power(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("power " + gameObject.name);
            itemMoveEffect.Value = "power";
            Invoke(nameof(ResetControls), 3f);
        }

        public void Double(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("double " + gameObject.name);
            itemMoveEffect.Value = "double";
            Invoke(nameof(ResetControls), 3f);
        }

        private void ResetControls()
        {
            Debug.Log("controls reset");
            itemMoveEffect.Value = "normal";
        }
    }
}
