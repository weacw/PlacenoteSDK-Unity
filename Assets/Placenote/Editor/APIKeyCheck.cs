﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using System.IO;



[CustomEditor(typeof(LibPlacenote))]
public class LibPlacenoteEditor : Editor, IPreprocessBuild
{
	public int callbackOrder { get { return 0; } }
	string filePath;
	void OnEnable()
	{
		// Setup the SerializedProperties.
		filePath = Application.persistentDataPath
			+ @"/apikey.dat";
	}
	public override void OnInspectorGUI()
	{
		var lib = target as LibPlacenote;
		DrawDefaultInspector ();
		StreamWriter writer = new StreamWriter (filePath, false);
		writer.WriteLine(lib.apiKey);
		writer.Close();
	}

	public void OnPreprocessBuild(BuildTarget target, string path) {
		StreamReader reader = new StreamReader(filePath); 
		string keyRead = reader.ReadToEnd ();
	
		if (keyRead == null) {
			Debug.LogError ("API Key Empty");
		} else if (keyRead.Trim () == "") {
			Debug.LogError ("API Key Empty");
		} else {
			Debug.Log ("API Key Entered:" + keyRead);
		}


		
		reader.Close();
	}
}
#endif

