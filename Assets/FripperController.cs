using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    private int FripperId = -1;
    private int width;

    // Use this for initialization
    void Start () {
        //HinjiJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        width = Screen.width;


    }
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        // タッチ数分繰り返し
        foreach (Touch touch in Input.touches)
        {
            // タッチの始まりを検知
            if (touch.phase == TouchPhase.Began)
            {

                // 右側タッチ時、右フリッパーを動かす
                if (touch.position.x > width / 2 && tag == "RightFripperTag")
                 {
                    FripperId = touch.fingerId; // fingerID保存
                    SetAngle(this.flickAngle);
                 }
                 // 左側タッチ時、左フリッパーを動かす
                 else if (touch.position.x <= width / 2 && tag == "LeftFripperTag")
                 {
                      FripperId = touch.fingerId; // fingerID保存
                      SetAngle(this.flickAngle);
                 }
            }
            // 指が離されるか、範囲外に出た時にfingerIDを元にフリッパーを元に戻す
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if(FripperId == touch.fingerId && tag == "RightFripperTag") 
                {
                    FripperId = -1; // fingerID初期化
                    SetAngle(this.defaultAngle);
                } else if(FripperId == touch.fingerId && tag == "LeftFripperTag")
                {
                    FripperId = -1; // fingerID初期化
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
