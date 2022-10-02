using TimingActionSample;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimingActionSample.Common;

namespace TimingActionSample
{
    public class NoteGenerator : MonoBehaviour
    {
        // 生成間隔
        [SerializeField] int interval = 1;

        // 生成数
        [SerializeField] int create_max = 5;

        // noteオブジェクト
        [SerializeField] GameObject NoteObj;
        [SerializeField] Transform Parent;

        // 画像オブジェクト
        [SerializeField] Sprite[] NoteGraphic;

        void Start()
        {
            StartCoroutine(NoteCreate(interval, create_max));
        }

        // Note作成
        IEnumerator NoteCreate(float time, int count)
        {
            for (int i = 0; i < count; i++) {
                yield return new WaitForSeconds(time);
                var obj = Instantiate(NoteObj, new Vector3(15, 0, 0), transform.rotation, Parent);
            }
        }

        //
        public Sprite GetSprite(NoteType type)
        {
            //DebugLogger.Log($"{type}({(int)type})");
            return NoteGraphic[(int)type];
        }

    }
}