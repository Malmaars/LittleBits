using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiHover : MonoBehaviour
{
    [SerializeField]
    private Sprite hoverSprite;
    private Sprite noHoverSprite;
    private Image sprite;
    [SerializeField]
    private bool fill = false;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = gameObject.transform.GetComponent<Image>();
        if (sprite == null){Debug.LogError("image missing");}
        noHoverSprite = sprite.sprite;
        if (noHoverSprite == null) { Debug.LogError("sprite missing"); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHover(bool _hovering) 
    {
        if (_hovering)
        {
            sprite.sprite = hoverSprite;
        }
        else
        {
            sprite.sprite = noHoverSprite;

        }
    }
}
