using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ModifiableInt : ModifieableProperty<int> {
		public ModifiableInt (int baseValue) : base(baseValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class AdditiveModifierInt : IModifier<int> {

		[SerializeField]
		int m_Amount;

		[SerializeField]
		int m_Priority;

		public int Amount { get => m_Amount; set => m_Amount = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public AdditiveModifierInt (int amount) {
			Amount = amount;
		}

		public int Evaluate (int value) {
			return value + Amount;
		}
	}

	[Serializable]
	public class SubtractiveModifierInt : IModifier<int> {

		[SerializeField]
		int m_Amount;

		[SerializeField]
		int m_Priority;

		public int Amount { get => m_Amount; set => m_Amount = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public SubtractiveModifierInt (int amount) {
			Amount = amount;
		}

		public int Evaluate (int value) {
			return value - Amount;
		}
	}

	[Serializable]
	public class MultiplyModifierInt : IModifier<int> {

		[SerializeField]
		float m_Multiply = 1f;

		[SerializeField]
		int m_Priority;

		public float Multiply { get => m_Multiply; set => m_Multiply = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public MultiplyModifierInt (float multiply) {
			Multiply = multiply;
		}

		public int Evaluate (int value) {
			return Mathf.RoundToInt(value * Multiply);
		}

	}

	[Serializable]
	public class DivisionModifierInt : IModifier<int> {

		[SerializeField]
		float m_Division = 1f;

		[SerializeField]
		int m_Priority;

		public float Division { get => m_Division; set => m_Division = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public DivisionModifierInt (float division) {
			Division = division;
		}

		public int Evaluate (int value) {
			return Mathf.RoundToInt(value / m_Division);
		}
	}

	#endregion

	/// <summary>
	/// The given value ignored and the returns specified value returned.
	/// </summary>
	[Serializable]
	public class SetModifierInt : SetModifier<int> {
		public SetModifierInt (int value,int priority = 0) : base(value,priority) {
		}
	}

}