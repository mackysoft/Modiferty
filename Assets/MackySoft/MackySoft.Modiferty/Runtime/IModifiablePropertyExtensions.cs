using System;
using System.Linq;

namespace MackySoft.Modiferty {
	public static class IModifiablePropertyExtensions {

		public static bool ContainsModifier<T> (this IReadOnlyModifiableProperty<T> source,IModifier<T> modifier) {
			return source.Modifiers.Contains(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Add(modifier);
		/// </summary>
		public static void AddModifier<T> (this IModifiableProperty<T> source,IModifier<T> modifier) {
			source.Modifiers.Add(modifier);
		}

		public static IDisposable AddModifierAsDisposable<T> (this IModifiableProperty<T> source,IModifier<T> modifier) {
			return source.Modifiers.AddModifierAsDisposable(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Remove(modifier);
		/// </summary>
		public static bool RemoveModifier<T> (this IModifiableProperty<T> source,IModifier<T> modifier) {
			return source.Modifiers.Remove(modifier);
		}

		/// <summary>
		/// Shortcut of <see cref="IModifiableProperty{T}.Modifiers"/>.Clear();
		/// </summary>
		public static void ClearModifiers<T> (this IModifiableProperty<T> source) {
			source.Modifiers.Clear();
		}

	}

}