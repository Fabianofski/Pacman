using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F4B1.Core.Ghost
{
    public class ChaseColor : MonoBehaviour
    {
        private Ghost ghost;
        public SpriteRenderer spriteRenderer;
        public Color ghostColor;
        public Color frightenedColor; 
        // Start is called before the first frame update
        void Awake()
        {
            ghost = GetComponent<Ghost>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ghost) return;
            Debug.Log(ghost.GhostIsFrightened());
            spriteRenderer.color = ghost.GhostIsFrightened() ? frightenedColor : ghostColor;
        }

    }
}
