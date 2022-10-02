using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimingActionSample.Common;

namespace TimingActionSample
{
    public class Controller : MonoBehaviour
    {
        // アニメーション
        [SerializeField] Animator ResultPerfect;
        [SerializeField] Animator ResultGood;
        [SerializeField] Animator ResultBad;
        [SerializeField] Animator ResultMiss;
        [SerializeField] Animator Frame;

        // アニメーション名
        [SerializeField] string ResultAnimationName;
        [SerializeField] string FrameAnimationName;

        [SerializeField] float radius = 1;
        
        //
        GameObject NoteObj;
        NoteType   nowNoteType;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                FrameJudge(NoteType.DOWN);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                FrameJudge(NoteType.UP);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                FrameJudge(NoteType.LEFT);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                FrameJudge(NoteType.RIGHT);
            }
        }

        // デバッグ用
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, radius);
        }

        // キー入力判定
        void FrameJudge(NoteType key)
        {
            // フレームアニメ
            Frame.Play(FrameAnimationName, 0, 0);
            RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, radius, Vector3.zero);
            if (hit2D) {

                // 誤入力判定
                if (hit2D.collider.GetComponent<NoteData>().GetNoteType() != key) {
                    ResultMiss.Play(ResultAnimationName, 0, 0);
                    return;
                }

                // 距離判定
                var distance = Mathf.Abs(hit2D.transform.position.x - transform.position.x);
                if      (distance < 0.2) ResultPerfect.Play(ResultAnimationName, 0, 0);
                else if (distance < 0.5) ResultGood.Play(ResultAnimationName, 0, 0);
                else if (distance < 0.8) ResultBad.Play(ResultAnimationName, 0, 0);
                else                     ResultMiss.Play(ResultAnimationName, 0, 0);

                Destroy(hit2D.collider.gameObject);
            }
        }
    }
}