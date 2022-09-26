using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Rendering.FilterWindow;

public class PlayerCraft : MonoBehaviour
{
    [SerializeField]
    private GameObject KeyContainer;
    [SerializeField]
    private GameObject Akey;
    private GameObject[] _collide = new GameObject[0];
    [SerializeField]
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_collide.Length > 0)
        {
            Akey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K))
            {
                menu.SetActive(!menu.activeSelf);
            }
        }
        else
        {
            Akey.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Station")
        {
            _collide=PushArr(_collide, collision.gameObject);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Station")
        {
            _collide =PopArr(_collide, collision.gameObject);
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    GameObject[] PushArr(GameObject[] _arr,GameObject item) {
        GameObject[] buffer = new GameObject[_arr.Length+1];
        for (int i = 0; i < _arr.Length; i++) 
        {
            buffer[i] = _arr[i]; 
        }
        buffer[buffer.Length - 1] = item;
        return buffer;
    }
    GameObject[] PopArr(GameObject[] _arr, GameObject item)
    {
        GameObject[] buffer = new GameObject[Mathf.Max(0,_arr.Length - 1)];
        for (int i = 0; i < buffer.Length; i++)
        {
            if (_arr[i] == item)
            {
                buffer[i] = _arr[i];
            }
        }
        return buffer;
    }
}
