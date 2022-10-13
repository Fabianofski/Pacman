using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using System.Diagnostics;
using UnityEngine;
using System.Runtime.InteropServices;

namespace F4B1.Core.Ghost
{
    public class GhostEyesRotator : MonoBehaviour
    {
        private GhostPathfinder ghostPathfinder;
        public SpriteRenderer spriteRenderer;
        public Sprite up;
        public Sprite down;
        public Sprite left;
        public Sprite right;
        // Start is called before the first frame update
        void Awake()
        {
            ghostPathfinder = transform.parent.GetComponent<GhostPathfinder>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ghostPathfinder) return;
            var dir = ghostPathfinder.currentDir;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            print(angle);
           
            if (angle == 90)
            {
                spriteRenderer.sprite = up;
            }
            else if(angle == 0)
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
