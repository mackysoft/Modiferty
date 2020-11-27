using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UniRx;
using NUnit.Framework;

namespace MackySoft.Modiferty.Tests {

	public class ReactiveModifiableIntTests {

		[UnityTest]
		public IEnumerator ObserveChanged_BaseValue () {
			ReactiveModifiableInt property = new ReactiveModifiableInt(0);
			var subscription = property.ObserveChanged().First().ToYieldInstruction();

			property.BaseValue = 1;

			yield return subscription;

			Assert.AreEqual(property.BaseValue,1);
		}

	}
}