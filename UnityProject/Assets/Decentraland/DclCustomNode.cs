﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace Dcl
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DclObject))]
    [AddComponentMenu("DclCustomNode", 1)]
    public class DclCustomNode : MonoBehaviour
    {
        public bool position;
        public bool rotation;
        public bool scale;

        public string nodeName;
        public List<XmlPropertyPair> propertyPairs;
        
#if UNITY_EDITOR
        
        [MenuItem("GameObject/DCL Object/Custom Node", false, -90)]
        static void CreateCustomNode()
        {
            GameObject gameObject = new GameObject("Custom Node");
            gameObject.transform.position = SceneView.lastActiveSceneView.pivot;
            gameObject.AddComponent<DclCustomNode>();
        }

#endif

#if UNITY_EDITOR

		[MenuItem("GameObject/DCL Object/Video", false, -90)]
		static void CreateVideo()
		{
			GameObject gameObject = new GameObject("Video");
			gameObject.transform.position = SceneView.lastActiveSceneView.pivot;


			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer> ();
			spriteRenderer.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Decentraland/Internal/Images/video_panel.png");//DclEditorSkin.VideoPanel;

			DclCustomNode node = gameObject.AddComponent<DclCustomNode>();
			node.position = node.rotation = node.scale = true;
			node.nodeName = "video";

			node.propertyPairs = new List<XmlPropertyPair> ();
			XmlPropertyPair pair;
			pair.name = "width";
			pair.value = "{1.98}";
			node.propertyPairs.Add (pair);

			pair.name = "height";
			pair.value = "{1.08}";
			node.propertyPairs.Add (pair);

			pair.name = "src";
			pair.value = "";
			node.propertyPairs.Add (pair);

			pair.name = "play";
			pair.value = "{true}";
			node.propertyPairs.Add (pair);

			pair.name = "volume";
			pair.value = "{20}";
			node.propertyPairs.Add (pair);
		}

#endif

    }

    [Serializable]
    public struct XmlPropertyPair
    {
        public string name;
        public string value;
    }
}