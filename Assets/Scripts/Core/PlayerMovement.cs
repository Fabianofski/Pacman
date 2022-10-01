// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Fabian Friedrich
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
        private Rigidbody2D rigidbody;
        private float movespeed = 5f;
        private Vector2 input;

        [SerializeField] private InputAction moveInputAction;

        private void Awake()
        {
            this.rigidbody = GetComponent<Rigidbody2D>();
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
            input = moveInputAction.ReadValue<Vector2>();
        }

        public void FixedUpdate()
        {
            rigidbody.velocity = input * movespeed;
        }

        public void InvertControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("invert" + gameObject.name);
            Invoke(nameof(ResetInvertedControls), 3f);
        }

        private void ResetInvertedControls()
        {
            Debug.Log("invert reset");
        }
    }
}
