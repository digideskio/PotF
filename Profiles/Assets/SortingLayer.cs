using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SortingLayer : MonoBehaviour {

	public int sortingLayerID;
	public int sortingOrder;
	public Image imageComponent;


	// Use this for initialization
	void Start () {
		imageComponent.canvasRenderer.renderer.sortingLayerID = sortingLayerID;
		imageComponent.canvasRenderer.renderer.sortingOrder = sortingOrder;

	}

}
