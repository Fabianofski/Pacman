// /**
//  * This file is part of: Pacman
//  * Created: 23.09.2022
//  * Copyright (C) 2022 Amelia Witon
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using F4B1.Core.Ghost.Behaviour;
using UnityEngine;

namespace F4B1.Core.Ghost.Appearance
{
    public class GhostEyesRotator : MonoBehaviour
    {
        private Behaviour.Ghost ghost;
        private GhostPathfinder ghostPathfinder;
        public SpriteRenderer spriteRenderer;
        public Sprite up;
        public Sprite down;
        public Sprite left;
        public Sprite right;
        public Sprite frightened;
        // Start is called before the first frame update
        void Awake()
        {
            ghostPathfinder = transform.parent.GetComponent<GhostPathfinder>();
            ghost = transform.parent.GetComponent<Behaviour.Ghost>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ghost) return;
            if (ghost.GhostIsFrightened() && ghost.ghostState != "DEAD")
            {
                spriteRenderer.sprite = frightened;
            }
            else
            {    if (!ghostPathfinder) return;
                var dir = ghostPathfinder.currentDir;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (angle == 90)
                {
                    spriteRenderer.sprite = up;
                }
                else if (angle == 0)
                {
                    spriteRenderer.sprite = right;
                }
                else if (angle == 180)
                {
                    spriteRenderer.sprite = left;
                }
                else if (angle == -90)
                {
                    spriteRenderer.sprite = down;
                }
            }


        }
    }
}
