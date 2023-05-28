using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField]
    private GameObject Frobot;

    [System.Serializable]
    public class SpawningSlot
    {
        public GameObject positionObject;

        public GameObject NPC;

        public Vector3 Position => positionObject.transform.position;
    }

    [SerializeField]
    private SpawningSlot[] spawnSlots;

    [SerializeField]
    private int numberOfNPCsToSpawn;


    public IEnumerator SpawnNPC ()
    {
        int limit = numberOfNPCsToSpawn;

        for(int i = 0; i < limit; i++)
        {
            if(i == limit)
            {
                i = 0;
            }

            if(!spawnSlots[i].NPC)
            {
                spawnSlots[i].NPC = Instantiate(Frobot, spawnSlots[i].Position, Quaternion.identity);
            }

            yield return new WaitForSeconds(2);
        }        
    }



    private void Start()
    {
        StartCoroutine(SpawnNPC());
    }
}