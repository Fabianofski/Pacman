// /**
//  * This file is part of: Pacman
//  * Created: 02.10.2022
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using EZCameraShake;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core.Player
{
    public class Health : MonoBehaviour
    {

        [SerializeField] private IntVariable life;
        private Vector2 spawnPoint;
        private bool invincible;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private float invincibilityDuration = 1;
        [SerializeField] private int blinkRate = 4;
        [SerializeField] private SoundEvent soundEvent;
        [SerializeField] private Sound hitSound;
        
        private void Start()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            life.Reset();
            spawnPoint = transform.position;
        }

        public void Hit()
        {
            if (invincible) return;
            CameraShaker.Instance.ShakeOnce(5, 0, .1f, .1f);
            soundEvent.Raise(hitSound);
            life.Value--;
            invincible = true;
            Blink();
            transform.position = spawnPoint;
            Invoke(nameof(ResetInvincibility), 1f);
        }

        private void Blink()
        {
            LeanTween.value(gameObject, 1, 0, invincibilityDuration / blinkRate).setOnUpdate((float val) =>
            {
                if (!spriteRenderer) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                var col = spriteRenderer.color;
                col.a = val;
                spriteRenderer.color = col;
            }).setLoopCount(blinkRate).setOnComplete(() =>
            {
                var col = spriteRenderer.color;
                col.a = 1;
                spriteRenderer.color = col;
            });
        }

        private void ResetInvincibility()
        {
            invincible = false;
        }
    }
}