using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Item : MonoBehaviour
    {

        [SerializeField] private GameObjectEvent itemEvent;
        private bool itemUsed;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player") || itemUsed) return;

            itemUsed = true;
            itemEvent.Raise(collision.gameObject);
        }

    }
}
