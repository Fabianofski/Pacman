using System.Collections.Generic;
using UnityEngine;

namespace F4B1.Core.Collectable
{
    public class ItemRandomizer : MonoBehaviour
    {
		public string spawnPointTag = "sometag";
		public bool alwaysSpawn = true;
		
		public List<GameObject> prefabsToSpawn;
		
		// Start is called before the first frame update
		void Start()
		{
			GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
			foreach(GameObject spawnPoint in spawnPoints){
				int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
				if(alwaysSpawn){
					GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
					pts.transform.position = spawnPoint.transform.position;
				}else{
					int spawnOrNot = Random.Range(0, 2);
					if(spawnOrNot == 0){
						GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
						pts.transform.position = spawnPoint.transform.position;
					}
				}
			}
		}
	}

}