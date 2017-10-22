using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

    private GameObject ScoreText;

     // Pointの初期化
    private int AddPoint = 0;
    private int TotalPoint = 0;

    // 各オブジェクトの点数の設定
    private int SmallStarTagPoint = 10;
    private int LargeStarTagPoint = 100;
    private int SmallCloudTagPoint = 30;
    private int LargeCloudTagPoint = 200;

	// Use this for initialization
	void Start () {

        // シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");

        // Scoreテキストの座標調整
        Vector2 pos = this.ScoreText.GetComponent<RectTransform>().sizeDelta;
        pos.x = Screen.width * 92 / 100;
        pos.y = Screen.height * 5 / 100;
        this.ScoreText.GetComponent<RectTransform>().sizeDelta = pos;
    }

    // Update is called once per frame
    void Update () {
//        Debug.Log(TotalPoint);
        this.ScoreText.GetComponent<Text>().text = "SCORE : "+ TotalPoint.ToString();
	}
    
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        // タグによって点数を変える。
        switch (other.gameObject.tag)
        {
            case "SmallStarTag":
                AddPoint = SmallStarTagPoint;
                break;
            case "LargeStarTag":
                AddPoint = LargeStarTagPoint;
                break;
            case "SmallCloudTag":
                AddPoint = SmallCloudTagPoint;
                break;
            case "LargeCloudTag":
                AddPoint = LargeCloudTagPoint;
                break;
            default:
                AddPoint = 0;
                break;
        }

        // 衝突時に点数を加算
        TotalPoint += AddPoint;
        //Debug.Log(TotalPoint);

        //カウンターストップ
        if (TotalPoint > 99999999)
            TotalPoint = 99999999;
    }
}



