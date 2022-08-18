using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalDebug
{
    public class DalakDebugHelper : MonoBehaviour
        {
            public struct TextInfo
            {
                public string text;
                public int fontSize;
                public Vector3 pos;
                public Color color;
            }
            public readonly DynamicArray<TextInfo> textInfos = new DynamicArray<TextInfo>(32);

            readonly GUIStyle style = new GUIStyle();
#if UNITY_EDITOR

            int resetDrawCall = 10;
            void Update()
            {
                resetDrawCall--;
                if (resetDrawCall <= 0)
                {
                    textInfos.numberOfItems = 0;
                }
            }
            void OnDrawGizmos()
            {
                resetDrawCall = 10;
                for (int i = 0; i < textInfos.numberOfItems; i++)
                {
                    ref var text = ref textInfos[i];
                    style.normal.textColor = text.color;
                    style.fontSize = text.fontSize;
                    style.fontStyle = FontStyle.Bold;
                    UnityEditor.Handles.Label(text.pos, text.text, style);
                }
                if (!UnityEditor.EditorApplication.isPaused)
                {
                    textInfos.numberOfItems = 0;
                }
            }
#endif
        }

        static DalakDebugHelper helper;

        static DalakDebugHelper Helper
        {
            get
            {
                if (helper == null)
                {
                    helper = new GameObject("Dalak Debug Helper").AddComponent<DalakDebugHelper>();
                    GameObject.DontDestroyOnLoad(helper.gameObject);
                }

                return helper;
            }
        }


        public static void DrawText(string text, Vector3 pos, Color color, int fontSize = 16)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }

            Helper.textInfos.Add(new DalakDebugHelper.TextInfo
            {
                text = text,
                color = color,
                pos = pos,
                fontSize = fontSize

            });
#endif

        }
}
