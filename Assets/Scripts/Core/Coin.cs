using UnityEngine;

namespace F4B1.Core
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int score;
        private bool coinCollected;
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player") || coinCollected) return;
            coinCollected = true;
            col.GetComponent<Score>().CoinCollected(score);
            Destroy(gameObject);
        }
    }
}
