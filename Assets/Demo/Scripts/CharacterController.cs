using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ActionDemo
{
	public class CharacterController : MonoBehaviour
	{
		CharacterBrain brain;
		CharacterStateController stateController;
		CharacterMovementController movementController;
		InputResolver inputResolver;
	}
}
