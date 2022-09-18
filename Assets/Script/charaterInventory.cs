using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaterInventory : MonoBehaviour
{
    private
    Dictionary<string, int> inventory = new Dictionary<string, int>()
        {
            {"item1" , 0},
            {"item2" , 0},
            {"item3" , 0},
        };    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collectable") {
            string name = collision.gameObject.name.Replace("(Clone)", "");
            inventory[name] += 1;
            Debug.Log( name + " " + inventory[name]);
            Destroy(collision.gameObject);
        }
    }

    public float[] CheckInventory(string[] nameList) 
    {
        float[] numberlist = new float[nameList.Length];
        Debug.Log(nameList[0].ToLower());
        for (int i = 0; i < nameList.Length; i++)
        {
            numberlist[i] = inventory[nameList[i].ToLower()];
        }
        return numberlist;
    }
}
