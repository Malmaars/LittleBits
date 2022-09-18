using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            menu.SetActive(!menu.activeSelf);
            if (!menu.activeSelf)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }

    }
    public void CloseMenu() 
    {
        menu.SetActive(false);    
    }
}
