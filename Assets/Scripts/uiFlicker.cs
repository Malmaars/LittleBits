using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiFlicker : MonoBehaviour
{
    [SerializeField]
    private float interval = 1f;
    [SerializeField]
    private GameObject[] _go;
    private int _idx = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (_go.Length>0)
        {
            StartCoroutine(StartFlicker());
        }
    }

    private void OnEnable()
    {
        if (_go.Length > 0)
        {
            StartCoroutine(StartFlicker());
        }
    }


    private IEnumerator StartFlicker() 
    {
        foreach (var item in _go)
        {
            item.SetActive(false);
        }
        _go[_idx].SetActive(true);
        _idx++;
        _idx %= _go.Length;
        yield return new WaitForSeconds(interval);
        StartCoroutine(StartFlicker());
    }
}
