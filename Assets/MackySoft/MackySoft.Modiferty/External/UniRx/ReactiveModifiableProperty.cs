using System;
using UniRx;

namespace MackySoft.Modiferty {

	public interface IReadOnlyReactiveModifiableProperty<T> : IReadOnlyModifiableProperty<T>, IReadOnlyReactiveProperty<T> {
		new IReadOnlyReactiveModifierList<T> Modifiers { get; } 
	}

	public interface IReactiveModifiableProperty<T> : IReadOnlyReactiveModifiableProperty<T>, IModifiableProperty<T>, IReactiveProperty<T> {
		new IReactiveModifierList<T> Modifiers { get; }
	}

	[Serializable]
	public class ReactiveModifiableProperty<T> : ReactiveProperty<T>, IReactiveModifiableProperty<T> {

		ReactiveModifierList<T> m_Modifiers;

		public T BaseValue {
			get => base.Value;
			set => base.Value = value;
		}

		new T Value {
			get => base.Value;
			set => base.Value = value;
		}
		
		public IReactiveModifierList<T> Modifiers => m_Modifiers ?? (m_Modifiers = new ReactiveModifierList<T>());

		public bool HasModifiers => (m_Modifiers != null) && (m_Modifiers.Count > 0);

		public ReactiveModifiableProperty () : this(default) {
		}

		public ReactiveModifiableProperty (T baseValue) : base(baseValue) {
		}

		public T Evaluate () {
			return (m_Modifiers != null) ? m_Modifiers.Evaluate(BaseValue) : BaseValue;
		}

		#region Explicit implementation

		IReadOnlyReactiveModifierList<T> IReadOnlyReactiveModifiableProperty<T>.Modifiers => Modifiers;

		IModifierList<T> IModifiableProperty<T>.Modifiers => Modifiers;

		IReadOnlyModifierList<T> IReadOnlyModifiableProperty<T>.Modifiers => Modifiers;

		#endregion

	}

	public static class ReactiveModifiablePropertyExtensions {

		/// <summary>
		/// Notify BaseValue and Modifiers changes.
		/// </summary>
		public static IObservable<IReadOnlyReactiveModifiableProperty<T>> ObserveChanged<T> (this IReadOnlyReactiveModifiableProperty<T> source) {
			if (source == null) {
				throw new ArgumentNullException(nameof(source));
			}
			return Observable.Merge(
				source.AsUnitObservable(),
				source.Modifiers.ObserveChanged().AsUnitObservable()
			).Select(_ => source);
		}

	}

}