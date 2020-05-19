using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ModifiableFloat : ModifieableProperty<float> {
		public ModifiableFloat (float baseValue) : base(baseValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class AdditiveModifierFloat : IModifier<float> {

		[SerializeField]
		float m_Amount;

		[SerializeField]
		int m_Priority;

		public float Amount { get => m_Amount; set => m_Amount = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public AdditiveModifierFloat (float amount) {
			Amount = amount;
		}

		public float Evaluate (float value) {
			return value + Amount;
		}

	}

	[Serializable]
	public class SubtractiveModifierFloat : IModifier<float> {

		[SerializeField]
		float m_Amount;

		[SerializeField]
		int m_Priority;

		public float Amount { get => m_Amount; set => m_Amount = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public SubtractiveModifierFloat (float amount) {
			Amount = amount;
		}

		public float Evaluate (float value) {
			return value - Amount;
		}
	}

	[Serializable]
	public class MultiplyModifierFloat : IModifier<float> {

		[SerializeField]
		float m_Multiply = 1;

		[SerializeField]
		int m_Priority;

		public float Multiply { get => m_Multiply; set => m_Multiply = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public MultiplyModifierFloat (float multiply) {
			Multiply = multiply;
		}

		public float Evaluate (float value) {
			return value * Multiply;
		}

	}

	[Serializable]
	public class DivisionModifierFloat : IModifier<float> {

		[SerializeField]
		float m_Division = 2f;

		[SerializeField]
		int m_Priority;

		public float Division { get => m_Division; set => m_Division = value; }

		public int Priority { get => m_Priority; set => m_Priority = value; }

		public DivisionModifierFloat (float division) {
			Division = division;
		}

		public float Evaluate (float value) {
			return value / m_Division;
		}
	}

	#endregion

	/// <summary>
	/// The given value ignored and the returns specified value returned.
	/// </summary>
	[Serializable]
	public class SetModifierFloat : SetModifier<float> {
		public SetModifierFloat (float value,int priority = 0) : base(value,priority) {
		}
	}

}