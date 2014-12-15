using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	public Texture2D frame;
	public Rect framePosition;

	public float horizontalDistance;
	public float verticleDistance;
	public float width;
	public float height;
	public Texture2D healthBar;
	public Rect HealthBarPosition;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void OnGUI()
	{
		drawFrame ();
		drawBar ();
	}

	void drawFrame()
	{
		framePosition.x = (Screen.width - framePosition.width) / 2;
		framePosition.width = Screen.width * 0.38f;
		framePosition.height = Screen.height * 0.048f;
		GUI.DrawTexture (framePosition, frame);
	}

	void drawBar()
	{
		HealthBarPosition.x = framePosition.x + framePosition.width * horizontalDistance;
		HealthBarPosition.y = framePosition.y + framePosition.height * verticleDistance;
		HealthBarPosition.width = framePosition.width * width;
		HealthBarPosition.height = framePosition.height * height;

		GUI.DrawTexture (HealthBarPosition, healthBar);
	}

}
