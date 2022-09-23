using UnityEngine;

namespace F4B1.Core
{
    public class RedGhost : MonoBehaviour
    {

        [SerializeField] private Transform destination;
        private GameObject[] players;

        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }


        private void Update()
        {
            var closestDistance = Mathf.Infinity;
            var nearestPlayer = new Vector2();
            foreach (var player in players)
            {
                var playerDistance = Vector2.Distance(transform.position, player.transform.position);
                if (!(playerDistance < closestDistance)) continue;
                closestDistance = playerDistance;
                nearestPlayer = player.transform.position;
            }

            destination.position = nearestPlayer;
        }
    }
}
