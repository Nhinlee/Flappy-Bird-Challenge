using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour, Spawner
{
    // Block object prefab to instantiate new object later
    [SerializeField] GameObject _blockTopPrefab;
    [SerializeField] GameObject _blockDownPrefab;

    // Block Factory Field
    GameObject[] _topFactory;
    GameObject[] _downFactory;
    
    // Distance of 2 block
    [SerializeField] float _maxDistance = 4f;
    [SerializeField] float _minDistance = 2.5f;
    [SerializeField] float _maxHigh = 4f; // This depend on camera size

    // Time between 2 object spawn in the scene
    [SerializeField] float _waitTimeToReSpawn = 1.5f;
    // Number object in spawner
    [SerializeField] int _ObjectNum = 5;

    private void Start()
    {
        // Initial instantiate block object
        InstantiateObject();
        // Start coroutine to spawn block 
        StartCoroutine(SpawnObject());
    }

    public void InstantiateObject()
    {
        // Create array have 5 element
        _topFactory = new GameObject[_ObjectNum];
        _downFactory = new GameObject[_ObjectNum];

        // Instantiate block
        for (int i = 0; i < _topFactory.Length; i++)
        {
            _topFactory[i] = Instantiate(_blockTopPrefab, transform.position, Quaternion.identity, this.transform);
            _topFactory[i].SetActive(false);
            _downFactory[i] = Instantiate(_blockDownPrefab, transform.position, Quaternion.identity, this.transform);
            _downFactory[i].SetActive(false);
        }
    }
    public IEnumerator SpawnObject()
    {
        while (true)
        {
            // This is depend on camera size
            // Current camera size is 5
            // This Spawner push certain in middle of the camera Y-Axis

            // Take This Object Position
            Vector2 pos = transform.position;
            // High in world view 
            float high = Random.Range(0f, _maxHigh);
            // Take Random distance beetween 2 block
            float dis = Random.Range(_minDistance, _maxDistance);

            GameObject blockTop = TakeOne(_topFactory);
            GameObject blockDown = TakeOne(_downFactory);
            if(blockDown != null && blockTop != null)
            {
                blockTop.transform.position = new Vector2(pos.x, pos.y + high);
                blockDown.transform.position = new Vector2(pos.x, pos.y + high - dis);
            }
            yield return new WaitForSeconds(_waitTimeToReSpawn);
        }
    }

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
