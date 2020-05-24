using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spawner
{
    void InstantiateObject();
    IEnumerator SpawnObject();
    GameObject TakeOne(GameObject[] factory);
}
