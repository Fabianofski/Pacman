using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F4B1
{
    public class ShopCoin : MonoBehaviour

    {
        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            col.GetComponent<Score>().CoinCollected(10);
            Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}