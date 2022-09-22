using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using static UnityEditor.Progress;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] _menuOption;
    [SerializeField]
    private RectTransform[] _optionOption;
    [SerializeField]
    private RectTransform[] _creditOption;
    [SerializeField]
    private GameObject[] _containers;
    [SerializeField]
    private GameObject _pointer;
    private RectTransform[] _option;
    private RectTransform[][] _optionArr;


    private int _currMenu = 0;
    private int _currPointer = 0;

    private float _music = 1;
    private float _sound = 1;

    // Start is called before the first frame update
    void Start()
    {
        _optionArr = new RectTransform[][] { _menuOption, _optionOption, _creditOption };
        _currMenu = 0;
        ShowMenu(_currMenu);

    }

    // Update is called once per frame
    void Update()
    {
        Selecting();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Hover(false);
            _currPointer--;
            _currPointer = (_currPointer + _option.Length) % _option.Length;
            MovePointer();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Hover(false);
            _currPointer++;
            _currPointer = (_currPointer + _option.Length) % _option.Length;
            MovePointer();
        }
    }

    void Selecting()
    {
            switch (_currMenu)
            {
                case 0:
                    SelectingMainMenu();
                    break;
                case 1:
                    SelectingOption();
                    break;
                case 2:
                    SelectingCredit();
                    break;
                default:
                    break;
            }

    }
    void SelectingMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (_currPointer == 0)
            {
                //load new scene
            }
            else
            {
                Hover(false);
                _currMenu = _currPointer;
                ShowMenu(_currMenu);
            }
        }
    }

    void SelectingOption()
    {
        Image _fill;
        switch (_currPointer)
        {
            case 0:
                _fill = GetFill();
                _music = FillBar(_music, _fill);
                break;
            case 1:
                _fill = GetFill();
                _sound = FillBar(_music, _fill);
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Hover(false);

                    _currMenu = 0;
                    ShowMenu(_currMenu);
                }
                break;
            default:
                break;
        }
        
    }
    Image GetFill()
    {
        Image fill = null;
        RectTransform[] _button = _option[_currPointer].GetComponentsInChildren<RectTransform>(true);
        fill = _button[1].gameObject.GetComponent<Image>();
        return fill;
    }

    float FillBar(float _bar, Image _fill)
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _bar = Mathf.Max(_bar - 0.1f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            _bar = Mathf.Min(_bar + 0.1f, 1f);


        }
        _fill.fillAmount = _bar;
        return _bar;
    }
    void SelectingCredit()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Hover(false);

            _currMenu = 0;
            ShowMenu(_currMenu);
        }
    }
    void ShowMenu(int _currMenu)
    {
        foreach (var item in _containers)
        {
            item.SetActive(false);
        }
        _containers[_currMenu].SetActive(true);

        _option = _optionArr[_currMenu];
        _currPointer = 0;
        MovePointer();
    }

    void MovePointer()
    {
        float _yPos = _option[_currPointer].transform.position.y;
        float _xPos = _option[_currPointer].rect.width * 4;
        int _screenWidth = UnityEngine.Screen.width;
        Vector3 _pointerPos = _pointer.transform.position;
        _pointerPos.y = _yPos;
        _pointerPos.x = _screenWidth / 2 - _xPos / 2 - 40;
        _pointer.transform.position = _pointerPos;
        Hover(true);
    }
    void Hover(bool _hovering)
    {
        uiHover _hover = _option[_currPointer].GetComponent<uiHover>();
        if (_hover == null) { Debug.LogError("ui is null"); }
        else
        {
            _hover.OnHover(_hovering);
        }
    }
}
