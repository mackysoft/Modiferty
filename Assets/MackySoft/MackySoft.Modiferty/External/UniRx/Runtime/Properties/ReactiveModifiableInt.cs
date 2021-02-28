using System;
using UnityEngine;
using MackySoft.Modiferty.Modifiers;

namespace MackySoft.Modiferty {

	[Serializable]
	public class ReactiveModifiableInt : ReactiveModifiableProperty<int> {
		public ReactiveModifiableInt () : this(default) {
		}
		public ReactiveModifiableInt (int baseValue) : base(baseValue) {
		}
	}

	#region Operator Modifiers

	[Serializable]
	public class ReactiveAdditiveModifierInt : ReactiveOperatorModifierBase<int> {

		public ReactiveAdditiveModifierInt () : this(default) {
		}
		public ReactiveAdditiveModifierInt (int baseValue) : base(baseValue) {
		}

		public override int Evaluate (int value) {
			return value + Evaluate();
		}

	}

	[Serializable]
	public class ReactiveSubtractiveModifierInt : ReactiveOperatorModifierBase<int> {

		public ReactiveSubtractiveModifierInt () : this(default) {
		}
		public ReactiveSubtractiveModifierInt (int baseValue) : base(baseValue) {
		}

		public override int Evaluate (int value) {
			return value - Evaluate();
		}

	}

	[Serializable]
	public class ReactiveMultiplyModifierInt : ReactiveOperatorModifierBase<float,int> {

		[SerializeField]
		RoundingMethod m_RoundingMethod;

		public RoundingMethod RoundingMethod {
			get => m_RoundingMethod;
			set => m_RoundingMethod = value;
		}

		public ReactiveMultiplyModifierInt () : this(1f) {
		}
		public ReactiveMultiplyModifierInt (float baseValue) : base(baseValue) {
		}
		public ReactiveMultiplyModifierInt (float baseValue,RoundingMethod roundingMethod) : this(baseValue) {
			m_RoundingMethod = roundingMethod;
		}

		public override int Evaluate (int value) {
			return (value * Evaluate()).RoundToInt(m_RoundingMethod);
		}

	}

	[Serializable]
	public class ReactiveDivisionModifierInt : ReactiveOperatorModifierBase<float,int> {

		[SerializeField]
		RoundingMethod m_RoundingMethod;

		public RoundingMethod RoundingMethod {
			get => m_RoundingMethod;
			set => m_RoundingMethod = value;
		}

		public ReactiveDivisionModifierInt () : this(1f) {
		}
		public ReactiveDivisionModifierInt (float baseValue) : base(baseValue) {
		}
		public ReactiveDivisionModifierInt (float baseValue,RoundingMethod roundingMethod) : this(baseValue) {
			m_RoundingMethod = roundingMethod;
		}

		public override int Evaluate (int value) {
			return (value / Evaluate()).RoundToInt(m_RoundingMethod);
		}

	}

	[Serializable]
	public class ReactiveSetModifierInt : ReactiveSetModifier<int> {
		public ReactiveSetModifierInt () : this(default) {
		}

		public ReactiveSetModifierInt (int baseValue) : base(baseValue) {
		}
	}

	[Serializable]
	public class ReactiveOperatorModifierInt : ReactiveOperatorModifierBase<float,int> {

		[SerializeField]
		OperatorType m_Type;

		[SerializeField]
		RoundingMethod m_RoundingMethod;

		public OperatorType Type {
			get => m_Type;
			set => m_Type = value;
		}

		public RoundingMethod RoundingMethod {
			get => m_RoundingMethod;
			set => m_RoundingMethod = value;
		}

		public ReactiveOperatorModifierInt () {
		}

		public ReactiveOperatorModifierInt (float baseValue) : base(baseValue) {
		}

		public override int Evaluate (int value) {
			switch (m_Type) {
				case OperatorType.Additive:
					return value + Evaluate().RoundToInt(m_RoundingMethod);
				case OperatorType.Subtractive:
					return value - Evaluate().RoundToInt(m_RoundingMethod);
				case OperatorType.Multiply:
					return (value * Evaluate()).RoundToInt(m_RoundingMethod);
				case OperatorType.Division:
					return (value / Evaluate()).RoundToInt(m_RoundingMethod);
				case OperatorType.Set:
					return Evaluate().RoundToInt(m_RoundingMethod);
				default:
					throw new NotSupportedException($"{nameof(OperatorType)}.{m_Type} does not supported.");
			}
		}
	}

	#endregion

}