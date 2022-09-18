using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        float _yPos = Random.Range(-1.5f, 3f);
        transform.position = new Vector3(7, _yPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.x<-7)
        {
            Destroy(gameObject);
        }
    }

}
