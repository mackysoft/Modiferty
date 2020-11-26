using System;
using UnityEngine;
using MackySoft.Modiferty.Modifiers;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ModifiableInt : ModifieableProperty<int> {
		public ModifiableInt () : this(default) {
		}
		public ModifiableInt (int baseValue) : base(baseValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class AdditiveModifierInt : OperatorModifierBase<int> {

		public AdditiveModifierInt () : this(default) {
		}

		public AdditiveModifierInt (int baseValue) : base(baseValue) {
		}

		public override int Evaluate (int value) {
			return value + Evaluate();
		}

	}

	[Serializable]
	public class SubtractiveModifierInt : OperatorModifierBase<int> {

		public SubtractiveModifierInt () : this(default) {
		}
		public SubtractiveModifierInt (int baseValue) : base(baseValue) {
		}

		public override int Evaluate (int value) {
			return value - Evaluate();
		}

	}

	[Serializable]
	public class MultiplyModifierInt : OperatorModifierBase<float,int> {

		[SerializeField]
		RoundingMethod m_RoundingMethod;

		public RoundingMethod RoundingMethod {
			get => m_RoundingMethod;
			set => m_RoundingMethod = value;
		}

		public MultiplyModifierInt () : this(1f) {
		}
		public MultiplyModifierInt (float baseValue) : base(baseValue) {
		}
		public MultiplyModifierInt (float baseValue,RoundingMethod roundingMethod) : this(baseValue) {
			m_RoundingMethod = roundingMethod;
		}

		public override int Evaluate (int value) {
			return (value * Evaluate()).RoundToInt(m_RoundingMethod);
		}

	}

	[Serializable]
	public class DivisionModifierInt : OperatorModifierBase<float,int> {

		[SerializeField]
		RoundingMethod m_RoundingMethod;

		public RoundingMethod RoundingMethod {
			get => m_RoundingMethod;
			set => m_RoundingMethod = value;
		}

		public DivisionModifierInt () : this(1f) {
		}
		public DivisionModifierInt (float baseValue) : base(baseValue) {
		}
		public DivisionModifierInt (float baseValue,RoundingMethod roundingMethod) : this(baseValue) {
			m_RoundingMethod = roundingMethod;
		}

		public override int Evaluate (int value) {
			return (value / Evaluate()).RoundToInt(m_RoundingMethod);
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