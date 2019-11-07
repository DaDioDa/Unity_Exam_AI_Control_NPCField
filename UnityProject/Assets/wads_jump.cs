using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wads_jump : MonoBehaviour {
    [Header("速度")]
    [Range(0,5)]
    public float speed;
    [Header("跳")]
    [Range(50, 500)]
    public float jump;
    [SerializeField]
    [Header("0001")]
    private bool ground; 
    Vector3 gofast = Vector3.zero;
    Rigidbody mysexybody;

    // Use this for initialization
    void Start () {
        mysexybody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

    }


    
    private void FixedUpdate()
    {
        movement();
        marioJump();
    }


    /// <summary>
    /// WASD移動
    /// </summary>
    void movement()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed, 0.0f, Input.GetAxis("Vertical")*speed);
    }


    /// <summary>
    /// Space跳
    /// </summary>
    void marioJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&ground == true)
        {
            mysexybody.AddForce(transform.up*jump);
            ground = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }
}
