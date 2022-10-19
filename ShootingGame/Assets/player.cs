using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    CharacterController cc;
    public Joystick joystick;

    void Start()
    {
        cc = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //取得方向輸入
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        //合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        //如果有方向輸入
        if (dir.magnitude > 0.1f)
        {
            
        //用座標差取得角度
        float faceAngle = Mathf.Atan2(h,v) * Mathf.Rad2Deg;

        //讓角色漸漸旋轉到指定角度
        Quaternion targetRotation = Quaternion.Euler(0 , faceAngle , 0);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,0.3f);

        }

//地心引力(y)
    if(!cc.isGrounded)
     {
    dir.y = -9.8f *5 * Time.deltaTime;

     }
        //推動rigidbody 來移動
        cc.Move(dir * Time.deltaTime * 10);
    }
}
