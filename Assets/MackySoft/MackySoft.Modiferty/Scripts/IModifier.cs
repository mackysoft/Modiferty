namespace MackySoft.Modiferty {

	public interface IModifier<T> {

		/// <summary>
		/// <para> Priority of evaluation. </para>
		/// <para> See: <see cref="ModifierList{T}.Evaluate(T)"/> </para>
		/// </summary>
		int Priority { get; }

		/// <summary>
		/// Evaluate the value.
		/// </summary>
		/// <param name="value"> Value to be modified. </param>
		T Evaluate (T value);

	}
}