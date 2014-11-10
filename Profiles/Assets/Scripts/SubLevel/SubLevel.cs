using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubLevel : ScriptableObject {

	public List<SubLevelElement> SubLevelItems; //in a chapter, one list or asset is used to store the different stages of that chapter, of which there are at most 2 or 3.

}
