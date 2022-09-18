using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] itemlist;
    private string[] namelist;
    [SerializeField]
    private charaterInventory _charInv;
    private bool firstLoad=true;
    // Start is called before the first frame update
    void Start()
    {
        namelist = new string[itemlist.Length];
        for (int i = 0; i < itemlist.Length; i++)
        {
            namelist[i] = itemlist[i].text;
        }
        LoadText();
        firstLoad = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (!firstLoad)
        {
            LoadText();
        }
    }
    private void LoadText() 
    {
        float[] numberlist;
        numberlist = _charInv.CheckInventory(namelist);
        for (int i = 0; i < itemlist.Length; i++)
        {
            itemlist[i].text = namelist[i] + ": " + numberlist[i];
        }
    }
}
