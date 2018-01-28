using Triggers;
using UnityEngine;

public class AppearingWords : MonoBehaviour {

    [SerializeField] private APassiveTriggerable _triggerOnSuccess1;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess2;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess3;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess4;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _triggerOnSuccess1.OnTrigger();
            _triggerOnSuccess2.OnTrigger();
            _triggerOnSuccess3.OnTrigger();
            _triggerOnSuccess4.OnTrigger();
        }
    }
}
