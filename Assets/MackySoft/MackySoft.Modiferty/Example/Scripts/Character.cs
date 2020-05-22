using System.Collections.Generic;
using UnityEngine;

namespace MackySoft.Modiferty.Example {
	public class Character : MonoBehaviour {

		public int health = 3;
		public ModifiableInt attackPower = new ModifiableInt(2);

		public void Attack (Character target) {
			target.health -= attackPower.Evaluate();
		}

	}

	public class CharacterWithoutModiferty : MonoBehaviour {

		public int health = 3;
		public int attackPower = 2;
		public int additionalAttackPower = 0;

		public void Attack (Character target) {
			target.health -= attackPower + additionalAttackPower;
		}
	}

	public class Character3 : MonoBehaviour {
		public int health = 3;
		public int attackPower = 2;
		public List<float> attackPowerMultiply = new List<float>();

		public void Attack (Character target) {
			int result = attackPower;
			foreach (float multiply in attackPowerMultiply) {

			}
			target.health -= attackPower + result;
		}
	}

	public class PowerUpItemWithoutModiferty : MonoBehaviour {

	}

}