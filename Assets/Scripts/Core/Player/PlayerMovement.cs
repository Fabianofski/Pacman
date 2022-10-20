// /**
//  * This file is part of: Pacman
//  * Created: 26.09.2022
//  * Copyright (C) 2022 Niklas Lischke
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace F4B1.Core.Player
{

[RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        [SerializeField] private FloatVariable moveSpeed;
        [SerializeField] private FloatVariable itemEffectDuration;
        private Vector2 direction;
        private int wallLayer;
        private Vector2 input;
        public Vector2 Input => direction;
        [SerializeField] private StringVariable itemMoveEffect;
        public bool PowerPellet { get; private set; }
        private bool pressed;
        private float timer;
        public bool DoubleScore { get; private set; }
        
        [SerializeField] private InputAction moveInputAction;
        
        [SerializeField] private SoundEvent soundEvent;
        [SerializeField] private Sound turnSound;

        private void Awake()
        {
            this.rb2d = GetComponent<Rigidbody2D>();
            moveInputAction.performed += _ => MoveBegin();
            moveInputAction.canceled += _ => pressed = false;
            wallLayer = LayerMask.GetMask("Tilemap");
            itemMoveEffect.Reset();
        }

        private void MoveBegin()
        {
            pressed = true;
            timer = .5f;
        }

        private void OnEnable()
        {
            moveInputAction.Enable();
        }

        private void OnDisable()
        {
            moveInputAction.Disable();
        }

        private void HandleInput()
        {
            timer -= Time.deltaTime;
            if (pressed) input = moveInputAction.ReadValue<Vector2>();
            if (timer < 0) return;
            var offset = (itemMoveEffect.Value == "inverted" ? -input : input);
            if (Physics2D.BoxCast(GetSnappedPosition() + offset, Vector2.one * .9f, 0, Vector2.zero, 0, wallLayer)) return;
            if (direction != input) soundEvent.Raise(turnSound);
            direction = input;
        }

        public void FixedUpdate()
        {
            HandleInput();

            DoubleScore = itemMoveEffect.Value == "double";
            PowerPellet = itemMoveEffect.Value == "power";
            
            switch(itemMoveEffect.Value)
            {
                case "normal":
                    rb2d.velocity = direction * moveSpeed.Value;
                    break;
                case "inverted":
                    rb2d.velocity = direction * -moveSpeed.Value;
                    break;
                case "frozen":
                    rb2d.velocity = Vector2.zero;
                    break;
                case "fast":
                    rb2d.velocity = direction * 10f;
                    break;
                case "slow":
                    rb2d.velocity = direction * 2f;
                    break;
                default:
                    rb2d.velocity = direction * moveSpeed.Value;
                    break;
            }           
        }

        private Vector2 GetSnappedPosition()
        {
            var pos = transform.position;
            pos = new Vector2(Mathf.Round(pos.x * 10) / 10, Mathf.Round(pos.y * 10) / 10);
            return pos;
        }

        public void InvertControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("invert " + gameObject.name);
            itemMoveEffect.Value = "inverted";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        public void FreezeControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("freeze " + gameObject.name);
            itemMoveEffect.Value = "frozen";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        public void SlowControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("slow " + gameObject.name);
            itemMoveEffect.Value = "slow";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        public void FastControls(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("fast " + gameObject.name);
            itemMoveEffect.Value = "fast";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        public void Power(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("power " + gameObject.name);
            itemMoveEffect.Value = "power";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        public void Double(GameObject sender)
        {
            if (sender.name != gameObject.name) return;
            Debug.Log("double " + gameObject.name);
            itemMoveEffect.Value = "double";
            CancelInvoke();
            Invoke(nameof(ResetControls), itemEffectDuration.Value);
        }

        private void ResetControls()
        {
            Debug.Log("controls reset");
            itemMoveEffect.Value = "normal";
        }
    }
}
