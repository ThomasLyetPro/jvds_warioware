using UnityEngine;

using System.Collections.Generic;

public class SkullBox : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private float delay;
    private float minthreshold = 0.3f;
    private float maxthreshold = 2f;
    private float initthreshold = 1f;

    private float randomthreshold = 0f;

    private Vector3 playerInitPos;

    void SpawnObject()
    {
        if(spawnedObjects.Count >= 5)
        {
           Destroy(spawnedObjects[0]);
           spawnedObjects.RemoveAt(0);
        }
        GameObject obj = Instantiate(prefab, playerInitPos, Quaternion.identity);
        spawnedObjects.Add(obj);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInitPos = GameObject.FindGameObjectWithTag("Player").transform.position + (Vector3.right * 1.5f) + (Vector3.up * 5);
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        float lthreshold = 0f;
        bool init = false;
        if ( initthreshold != 0 )
        {
            lthreshold = initthreshold;
            init = true;
        }
        else
        {
            if (randomthreshold == 0f)
                randomthreshold = Random.Range(minthreshold, maxthreshold);
            lthreshold = randomthreshold;
        }
        if(delay > lthreshold)
        {
            print(delay + " +  "+  init );
            delay = 0;
            randomthreshold = 0;
            SpawnObject();
            if (init)
                initthreshold = 0;
        }
    }
}
