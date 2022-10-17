using System.Collections;
using TMPro;
using UnityEngine;

namespace F4B1.UI.Game
{
    public class ReadyScreen : MonoBehaviour
    {

        [SerializeField] private float readyTime;
        
        private void Awake()
        {
            StartCoroutine(StartGame());
            StartCoroutine(AnimateText());
        }

        private IEnumerator StartGame()
        {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(readyTime);
            Time.timeScale = 1;
            Destroy(gameObject);
        }

        private IEnumerator AnimateText()
        {
            gameObject.transform.localScale = Vector3.zero;
            LeanTween.scale(gameObject, Vector3.one, readyTime / 4).setIgnoreTimeScale(true);;
            
            LeanTween.value(gameObject, 0, 1, readyTime / 2).setOnUpdate(val =>
            {
                var text = GetComponentInChildren<TextMeshProUGUI>();
                var col = text.color;
                col.a = val;
                text.color = col;
            }).setIgnoreTimeScale(true);
            
            yield return new WaitForSecondsRealtime((readyTime/4) * 3);
            
            LeanTween.value(gameObject, 1, 0, readyTime / 4).setOnUpdate((val) =>
            {
                var text = GetComponentInChildren<TextMeshProUGUI>();
                var col = text.color;
                col.a = val;
                text.color = col;
            }).setIgnoreTimeScale(true);;
        }
    }
}