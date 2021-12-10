﻿using UnityEngine;
using UnityEngine.UI;

public class FrameRateHandler : MonoBehaviour {
	public Text frameText;

	void Start() {
		// For accurate FPS measuring
		QualitySettings.vSyncCount = 0;
	}

	void Update() {
		float value = Mathf.Floor(1.0f / Time.deltaTime);
		frameText.text = string.Format("Estimated FPS: {0}", value);
	}

	public void SetFrameRateDefault() {
		print("Switch targetFrameRate to -1");
		Application.targetFrameRate = -1;
	}

	public void SetFrameRate30() {
		print("Switch targetFrameRate to 30");
		Application.targetFrameRate = 30;
	}

	public void SetFrameRate60() {
		print("Switch targetFrameRate to 60");
		Application.targetFrameRate = 60;
	}

	public void SetFrameRate120() {
		print("Switch targetFrameRate to 120");
		Application.targetFrameRate = 120;
	}
}
