using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimingActionSample.Common;

namespace TimingActionSample
{
    public class NoteData : MonoBehaviour
    {
        [SerializeField] float movespeed = 0.01f;
        [SerializeField] NoteType noteType;

        void Start()
        {
            // パラメータ設定
            var type = UnityEngine.Random.Range(0, Enum.GetValues(typeof(NoteType)).Length);
            noteType = (NoteType)type;

            // 画像合わせ
            transform.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Script").GetComponent<NoteGenerator>().GetSprite(noteType);

        }

        void Update()
        {
            var pos = transform.position;
            pos.x -= movespeed;
            transform.position = pos;
        }

        public NoteType GetNoteType()
        {
            return noteType;
        }

    }

}