
using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox.Amid.Scripts;
using UnityEngine;

public class GenericTrigger : MonoBehaviour
{
	[SerializeField] private List<ATriggerable> _triggerables; 
	
	void OnTriggerEnter(Collider other) => _triggerables.ForEach(it => it.TriggerEnter(other));
	void OnTriggerExit(Collider other) => _triggerables.ForEach(it => it.TriggerExit(other));
}
