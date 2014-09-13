using UnityEngine;
using System.Collections;

public class ProfileList : MonoBehaviour {

	private Vector3 initListPosition;
	private Vector3 currentListPosition;
	public float listHeight;

	// Find ProfileList Height and Position
	void Start () {
		currentListPosition = transform.position;
		listHeight = (renderer.bounds.max.y - renderer.bounds.min.y);
	}

	//Move List Up or Down
	public void MoveDown(){
		if (currentListPosition.y > initListPosition.y) {
			transform.Translate (0,-(((listHeight-14F)/8)+2),0, Space.Self); //14 accounts for the gap between each profile, this must be hardcoded because it is a graphical distance
			currentListPosition = transform.position;
		}
	}

	public void MoveUp(){
		if (Vector3.Distance (initListPosition, currentListPosition) < ((3*listHeight)/5)) { //stops the bar from going too far down
			transform.Translate (0,(((listHeight-14F)/8)+2),0, Space.Self);
			currentListPosition = transform.position;
			}
		}
	
}