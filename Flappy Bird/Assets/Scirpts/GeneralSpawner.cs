using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSpawner : MonoBehaviour, Spawner
{
    // Prefab Object
    [SerializeField] GameObject _prefab;

    // Factory 
    GameObject[] _Factory;

    // Time between 2 object spawn in the scene
    [SerializeField] float _waitTimeToReSpawn = 2f;
    // Number object in spawner
    [SerializeField] int _objectNum = 5;
    [SerializeField] float _maxHigh = 6f;
    [SerializeField] float _minHigh = 0f;

    private void Start()
    {
        // Instantiate Game Object In Factory (Array)
        InstantiateObject();
        // Start Coroutine to spawn game object to the scene
        StartCoroutine(SpawnObject());
    }

    public void InstantiateObject()
    {
        // Create array have 5 element
        _Factory = new GameObject[_objectNum];

        // Instantiate block
        for (int i = 0; i < _Factory.Length; i++)
        {
            _Factory[i] = Instantiate(_prefab, transform.position, Quaternion.identity, this.transform);
            _Factory[i].SetActive(false);
        }
    }

    public IEnumerator SpawnObject()
    {
        while (true)
        {
            // Take position of spawner
            Vector2 pos = this.transform.position;
            // High in world view 
            float randomHigh = Random.Range(_minHigh, _maxHigh);
            // Take One Cloud From Factory
            GameObject cloud = TakeOne(_Factory);
            if (cloud != null)
            {
                cloud.transform.position = new Vector2(pos.x, pos.y + randomHigh);
            }
            // Yield Return
            yield return new WaitForSeconds(_waitTimeToReSpawn);
        }
    }

    // This Function can be resused
    // But i try with Abstract class and it warning me about abstract class can't be inherit from "Monobehavior"
    public GameObject TakeOne(GameObject[] factory)
    {
        foreach (GameObject block in factory)
        {
            if (!block.activeInHierarchy)
            {
                block.SetActive(true);
                return block;
            }
        }
        return null;
    }
}
