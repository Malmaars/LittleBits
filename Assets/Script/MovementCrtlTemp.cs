using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MovementCrtlTemp : MonoBehaviour
{
    [SerializeField]
    private float _speed =  5;
    [SerializeField]
    private float _height = 5;
    [SerializeField]
    private Collider2D _foot;

    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private float _groundedOffset = -0.14f;
    [SerializeField]
    private float _groundedRadius = 0.28f;
    [SerializeField]
    private LayerMask _groundLayers;
    [SerializeField]
    private bool _visualizeGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        CheckGround();
    }
    private void Move()
    {
        float _horiz = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.J) && _grounded)
        {
            StartCoroutine(Jump());
        }

        transform.Translate(new Vector3(_horiz * _speed * Time.deltaTime, 0f, 0f));
    }
  

    private void CheckGround() 
    {
        Vector2 circlePos = new Vector2(transform.position.x, transform.position.y - _groundedOffset);
        Collider2D[] _hit = Physics2D.OverlapCircleAll(circlePos, _groundedRadius);
        foreach (var item in _hit)
        {
            if (item.tag == "stage")
            {
                _grounded = true;
            }
            else 
            {
                _grounded = false;
            }
        }
    }
    void OnDrawGizmosSelected() {
        if (_visualizeGround)
        {
            Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - _groundedOffset, transform.position.z), _groundedRadius);
        }
    }
    private IEnumerator Jump() {
        for (int i = 0; i <25;i++) {
            transform.Translate(Vector3.up * _height * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
