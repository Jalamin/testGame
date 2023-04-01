using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;

    public static bool _hide;
    [SerializeField] private float _hideTime;

    private Rigidbody2D _rb;
    private Vector2 _dir;
    private SpriteRenderer _sr;

    void Start()
    {
        var view = transform.GetChild(0);
        _rb = GetComponent<Rigidbody2D>();
        _sr = view.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");

        if(!_hide)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _hide = true;
                _speed = 0;
                _sr.color = Color.white * 0.5f;
            }
        }
        else _hideTime -= Time.deltaTime;

        if (_hideTime < 0)
        {
            _hide = false;
            _speed = 5;
            _hideTime = 5;
            _sr.color = Color.white * 1f;
        }

        if(_health <= 0) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _dir * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
