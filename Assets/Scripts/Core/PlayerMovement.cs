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
        private bool inverted = false;
        private bool freeze = false;
        private string itemmoveeffect = "normal";

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
            switch(itemmoveeffect)
            {
                case "normal":
                    rigidbody.velocity = input * movespeed;
                    break;
                case "inverted":
                    rigidbody.velocity = input * -1 * movespeed;
                    break;
                case "frozen":
                    rigidbody.velocity = Vector2.zero;
                    break;
                case "fast":
                    rigidbody.velocity = input * 10f;
                    break;
                case "slow":
                    rigidbody.velocity = input * 2f;
                    break;
            }           
        }

        public void InvertControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("invert " + gameObject.name);
            itemmoveeffect = "inverted";
            Invoke(nameof(ResetControls), 3f);
        }

        public void FreezeControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("freeze " + gameObject.name);
            itemmoveeffect = "frozen";
            Invoke(nameof(ResetControls), 3f);
        }

        public void SlowControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("slow " + gameObject.name);
            itemmoveeffect = "slow";
            Invoke(nameof(ResetControls), 3f);
        }

        public void FastControls(GameObject sender)
        {
            if (sender.name == gameObject.name) return;
            Debug.Log("fast " + gameObject.name);
            itemmoveeffect = "fast";
            Invoke(nameof(ResetControls), 3f);
        }

        private void ResetControls()
        {
            Debug.Log("controls reset");
            itemmoveeffect = "normal";
        }
    }
}
