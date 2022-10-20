using UnityEngine;

namespace F4B1.Core.Ghost.Appearance
{
    public class ChaseColor : MonoBehaviour
    {
        private Behaviour.Ghost ghost;
        public SpriteRenderer spriteRenderer;
        public Color ghostColor;
        public Color frightenedColor; 
        // Start is called before the first frame update
        void Awake()
        {
            ghost = GetComponent<Behaviour.Ghost>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ghost) return;
            spriteRenderer.enabled = ghost.ghostState != "DEAD";
            spriteRenderer.color = ghost.GhostIsFrightened() ? frightenedColor : ghostColor;
        }

    }
}
