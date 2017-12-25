using UnityEngine;

public class Note : MonoBehaviour {
	
	//The Text Of The Note
	public string Text = "Insert Your Text Here!";
	
	void Start () {

        Text = Text.Replace("NEWLINE", "\n");
        Text = Text.Replace("TAB", "\t");
        //Text = Text.Replace("TAB3", "\t\t\t\t\t");

        //AutoSet the Name
        transform.name = "Note";
		
		//If there is no collider on the note add one
		if (GetComponent<Collider>() == null) {
			
			Debug.LogError ("No Collider On Note " + name + ". Add A Collider!");
			
		}
		
	}
		
}
