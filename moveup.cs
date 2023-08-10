using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //剛體
    public Rigidbody rBody;
    //是否在地面
    private bool isGround;


    void Start()
    {
        //獲取剛體組件
        rBody = GetComponent<Rigidbody>();
    }
    

    
    void Update()
    {
        //如果按下空格鍵 並且角色在地面上
        if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //給剛體一個向上的力(跳躍)
            rBody.AddForce(Vector3.up * 200);
        } 
        //是不按下移動鍵
        //按下w和d的時候分別給我們返回1和-1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

    }
    
    //產生碰撞
    private void OnCollisionEnter(Collision collision) 
    {
        //判斷是不是地面
        if(collision.collider.tag == "Ground")
        {
            //踩在地面上了
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //判斷是不是地面
        if(collision.collider.tag == "Ground")
        {
            //離開地面上了
            isGround = false;
        }
    }
}
