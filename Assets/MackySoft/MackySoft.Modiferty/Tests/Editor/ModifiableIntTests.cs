using System;
using UnityEngine;
using NUnit.Framework;

namespace MackySoft.Modiferty.Tests {

	public class ModifiableIntTests {

		[Test]
		public void Solo ([Random(-99999,99999,10)] int baseValue) {
			var property = new ModifiableInt(baseValue);
			Assert.AreEqual(baseValue,property.Evaluate());
		}
		
		[Test]
		public void Additive (
			[Random(-99999,99999,10)] int baseValue,
			[Random(-99999,99999,10)] int add
		) {
			var property = new ModifiableInt(baseValue);
			property.AddModifier(new AdditiveModifierInt(add));
			Assert.AreEqual(baseValue + add,property.Evaluate());
		}

		[Test]
		public void Subtractive (
			[Random(-99999,99999,10)] int baseValue,
			[Random(-99999,99999,10)] int subtract
		) {
			var property = new ModifiableInt(baseValue);
			property.AddModifier(new SubtractiveModifierInt(subtract));
			Assert.AreEqual(baseValue - subtract,property.Evaluate());
		}

		[Test]
		public void Multiply (
			[Random(-99999,99999,10)] int baseValue,
			[Random(-10f,10f,10)] float multiplier,
			[Values] RoundingMethod method
		) {
			var property = new ModifiableInt(baseValue);
			property.AddModifier(new MultiplyModifierInt(multiplier,method));
			Assert.AreEqual(RoundUtility.RoundToInt(baseValue * multiplier,method),property.Evaluate());
		}

		[Test]
		public void Division (
			[Random(-99999,99999,10)] int baseValue,
			[Random(-10f,10f,10)] float division,
			[Values] RoundingMethod method
		) {
			var property = new ModifiableInt(baseValue);
			property.AddModifier(new DivisionModifierInt(division,method));
			Assert.AreEqual(RoundUtility.RoundToInt(baseValue / division,method),property.Evaluate());
		}

		[Test]
		public void AddModifierAsDisposable () {
			var property = new ModifiableInt(0);

			IDisposable disposable = property.AddModifierAsDisposable(new AdditiveModifierInt(1));
			int beforeDisposedValue = property.Evaluate();

			disposable.Dispose();

			int afterDisposedValue = property.Evaluate();
			Assert.AreNotEqual(beforeDisposedValue,afterDisposedValue);
		}

	}
}