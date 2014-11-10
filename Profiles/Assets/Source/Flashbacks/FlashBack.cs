using UnityEngine;
using System.Collections;

public enum FlashBacks {First, Second, Third};

public class FlashBack : MonoBehaviour {

	public FlashBacks flashBack;

	public void AddToFlashBackList()
	{
		FlashBackContainer.AddToFlashBack (flashBack);
	}

}
