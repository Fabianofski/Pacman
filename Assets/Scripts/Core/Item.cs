// /**
//  * This file is part of: Pacman
//  * Created: 02.10.2022
//  * Copyright (C) 2022 Niklas Lischke
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using EZCameraShake;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Item : MonoBehaviour
    {

        [SerializeField] private GameObjectEvent itemEvent;
        [SerializeField] private SoundEvent soundEvent;
        [SerializeField] private Sound pickUpSound;
        private bool itemUsed;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || itemUsed) return;
            
            CameraShaker.Instance.ShakeOnce(1, 0, .1f, .1f);
            itemUsed = true;
            if (pickUpSound) soundEvent.Raise(pickUpSound);
            itemEvent.Raise(collision.gameObject);
        }

    }
}
