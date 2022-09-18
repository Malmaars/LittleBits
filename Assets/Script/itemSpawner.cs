using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] _itemList;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnItem() {
        int _idx = Random.Range(0, _itemList.Length);
    Instantiate(_itemList[_idx]);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnItem());

    }
}
