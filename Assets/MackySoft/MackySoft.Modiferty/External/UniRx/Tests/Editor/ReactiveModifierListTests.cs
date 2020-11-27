using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UniRx;
using NUnit.Framework;

namespace MackySoft.Modiferty.Tests {
	public class ReactiveModifierListTests {

		[UnityTest]
		public IEnumerator ObserveChanged_Add () {
			var modifiers = new ReactiveModifierList<int>();
			
			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			modifiers.Add(new AdditiveModifierInt(1));

			yield return subscription;

			Assert.AreEqual(modifiers.Count,1);
		}

		[UnityTest]
		public IEnumerator ObserveChanged_Remove () {
			var modifiers = new ReactiveModifierList<int>();
			var modifier = new AdditiveModifierInt(1);
			modifiers.Add(modifier);

			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			modifiers.Remove(modifier);

			yield return subscription;

			Assert.AreEqual(modifiers.Count,0);
		}

		[UnityTest]
		public IEnumerator ObserveChanged_Insert () {
			var modifiers = new ReactiveModifierList<int>();
			modifiers.Add(new AdditiveModifierInt(1));

			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			modifiers.Insert(0,new SubtractiveModifierInt(1));

			yield return subscription;

			Assert.AreEqual(modifiers.Count,2);
		}

		[UnityTest]
		public IEnumerator ObserveChanged_Move () {
			var modifiers = new ReactiveModifierList<int>();
			modifiers.Add(new AdditiveModifierInt(1));

			var targetModifier = new SubtractiveModifierInt(1);
			modifiers.Add(targetModifier);

			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			modifiers.Move(1,0);

			yield return subscription;

			Assert.AreEqual(modifiers.IndexOf(targetModifier),0);
		}

		[UnityTest]
		public IEnumerator ObserveChanged_Replace () {
			var modifiers = new ReactiveModifierList<int>();
			modifiers.Add(new AdditiveModifierInt(1));

			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			var targetModifier = new SubtractiveModifierInt(1);
			modifiers[0] = targetModifier;

			yield return subscription;

			Assert.AreSame(modifiers[0],targetModifier);
		}

		[UnityTest]
		public IEnumerator ObserveChanged_Clear () {
			var modifiers = new ReactiveModifierList<int>();
			modifiers.Add(new AdditiveModifierInt(1));

			var subscription = modifiers.ObserveChanged().First().ToYieldInstruction();

			modifiers.Clear();

			yield return subscription;

			Assert.AreEqual(modifiers.Count,0);
		}

	}
}