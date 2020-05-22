using System.Linq;

namespace MackySoft.Modiferty {
	public static class IModifiablePropertyExtensions {

		public static bool Contains<T> (this IReadOnlyModifiableProperty<T> source,IModifier<T> modifier) {
			return source.Modifiers.Contains(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Add(modifier);
		/// </summary>
		public static void Add<T> (this IModifiableProperty<T> source,IModifier<T> modifier) {
			source.Modifiers.Add(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Remove(modifier);
		/// </summary>
		public static bool Remove<T> (this IModifiableProperty<T> source,IModifier<T> modifier) {
			return source.Modifiers.Remove(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Clear();
		/// </summary>
		public static void Clear<T> (this IModifiableProperty<T> source) {
			source.Modifiers.Clear();
		}

	}

}