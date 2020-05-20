using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	/// <summary>
	/// Create complex modifier improvise.
	/// </summary>
	[Serializable]
	public class CreateModifier<T> : IModifier<T> {

		[SerializeField]
		int m_Priority;

		[NonSerialized]
		Func<T,T> m_Evaluator;

		public Func<T,T> Evaluator {
			get => m_Evaluator;
			set => m_Evaluator = value ?? throw new NullReferenceException($"You cannot set the {nameof(Evaluator)} to null.");
		}

		public int Priority { get => m_Priority; set => m_Priority = value; }

		/// <param name="evaluator"> Evaluator can not be null. </param>
		public CreateModifier (Func<T,T> evaluator,int priority = 0) {
			Evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
			Priority = priority;
		}

		public T Evaluate (T value) {
			return Evaluator.Invoke(value);
		}

	}

}