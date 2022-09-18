using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    private int _idx = 0;
    private float _music = 1;
    private float _sound = 1;

    // Start is called before the first frame update
    void Start()
    {
        _option = _menuOption;
        _idx = 0;
        MovePointer();

    }

    // Update is called once per frame
    void Update()
    {
        Selecting();
        if (Input.anyKeyDown)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                _idx--;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                _idx++;
            }
        }
        _idx = (_idx + _option.Length) % _option.Length;
        MovePointer();



    }
    void Selecting() {

 
            if (_containers[0].activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    SelectingMainMenu();
                }
            }
            else if (_containers[1].activeSelf)
            {
                SelectingOption();
            }
            else if (_containers[2].activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    SelectingCredit();
                }
            }
        
    }
    void SelectingMainMenu()
    {
        switch (_idx)
        {
            case 0:
                //loadnewscene
                break;
            case 1:
                _option = _optionOption;
                _containers[0].SetActive(false);
                _containers[1].SetActive(true);
                _idx = 0;
                break;
            case 2:
                _option = _creditOption;
                _containers[0].SetActive(false);
                _containers[2].SetActive(true);
                _idx = 0;
                break;
            default:
                break;
        }

    }
    void SelectingOption()
    {
        Image _fill;
        switch (_idx)
        {
            case 0:
                _fill = _optionOption[_idx].gameObject.GetComponent<Image>();

                 _music = FillBar(_music, _fill);
                Debug.Log(_fill.name);

                break;
            case 1:
                _fill = _optionOption[_idx].gameObject.GetComponent<Image>();
                _sound = FillBar(_sound, _fill);
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.G))
                {
                    _option = _menuOption;
                    _containers[0].SetActive(true);
                    _containers[1].SetActive(false);
                    _idx = 1;
                }
                break;
            default:
                break;
        }
    }
    float FillBar (float _bar , Image _fill)
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _bar = Mathf.Max(_bar - 0.1f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
             
           _bar = Mathf.Min(_bar + 0.1f, 1f);


        }
        Debug.Log(_bar);
        _fill.fillAmount = _bar;
        return _bar;
    }
    void SelectingCredit()
    {

        _option = _menuOption;
        _containers[0].SetActive(true);
        _containers[2].SetActive(false);
        _idx = 2;

    }
    void MovePointer() {
        float _yPos = _option[_idx].transform.position.y;
        float _xPos = _option[_idx].sizeDelta.x;
        int _screenWidth = UnityEngine.Screen.width;
        Vector3 _pointerPos = _pointer.transform.position;
        _pointerPos.y = _yPos;
        _pointerPos.x = _screenWidth / 2-_xPos/2-25;
        _pointer.transform.position = _pointerPos;
    }
}
