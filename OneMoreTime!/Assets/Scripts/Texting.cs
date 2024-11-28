using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texting : MonoBehaviour
{
    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        t.text = "当前回合数："+Map.rndCount;
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "当前回合数：" + Map.rndCount+"\n机会剩余："+Runner.lifeLeft;
        if (Runner.lifeLeft == -1)
            t.text = "游戏失败！";
        if (Runner.rprop > 0)
            t.text += "\n加速剩余："+Runner.rprop;
        if (Runner.flag > 0)
            t.text += "\n无敌剩余：" + Runner.flag;
    }
}
