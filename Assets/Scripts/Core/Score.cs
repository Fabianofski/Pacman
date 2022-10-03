using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace F4B1.Core
{
    public class Score : MonoBehaviour
    {

        [SerializeField] private IntVariable score;


        private void Awake()
        {
            score.Reset();
        }
        public void CoinCollected(int i)
        {
            score.Value += i;
        }
    }
}
