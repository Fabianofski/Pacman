using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace F4B1
{
    public class Item : MonoBehaviour
    {

        [SerializeField] private GameObjectEvent itemEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;

            itemEvent.Raise(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
