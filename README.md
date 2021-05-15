# Modiferty - Property Modification

**Created by Hiroya Aramaki ([Makihiro](https://twitter.com/makihiro_dev))**

[![Tests](https://github.com/mackysoft/Modiferty/actions/workflows/tests.yaml/badge.svg)](https://github.com/mackysoft/Modiferty/actions/workflows/tests.yaml)
[![Build](https://github.com/mackysoft/Modiferty/actions/workflows/build.yaml/badge.svg)](https://github.com/mackysoft/Modiferty/actions/workflows/build.yaml)
[![Release](https://img.shields.io/github/v/release/mackysoft/Modiferty)](https://github.com/mackysoft/Modiferty/releases)
[![openupm](https://img.shields.io/npm/v/com.mackysoft.modiferty?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.mackysoft.modiferty/)

## What is Modiferty ?

Modiferty is a great solution for making modifications to properties.

In games, there are often situations in which the status of characters, weapons, etc. temporarily change.

Modiferty can be used in the following situations.

- Want to modify the in-game character status temporally.

## <a id="index" href="#index"> Table of Contents </a>

- [Installation](#installation)
- [Usage](#usage)
  - [Using ModifierList](#using-modifierlist)
- [Modifier Types](#modifier-types)
	- [Set Modifier](#set-modifier)
	- [Create Modifier](#create-modifier)
- [External Assets](#external-assets)
  - [UniRx](#unirx)
- [Author Info](#author-info)
- [License](#license)

# <a id="installation" href="#installation"> Installation </a>

Download any version from releases.

Releases: https://github.com/mackysoft/Modiferty/releases

# <a id="usage" href="#requirements"> Usage </a>

Add "MackySoft.Modiferty" namespace into using area.

```cs
using MackySoft.Modiferty;
```

The following code implements a temporary increase the character attack power.

```cs
public class Character : MonoBehaviour {

	public int health = 3;
	public ModifiableInt attackPower = new ModifiableInt(baseValue: 1);

	public void Attack (Character target){
		target.health -= attackPower.Evaluate();
	}

}

public class PowerUpItem : MonoBehaviour {

	public AdditiveModifierInt additivePower = new AdditiveModifierInt(1);

	public void Modify (Character target){
		target.attackPower.Modifiers.Add(additivePower);

		// Same as below.
		// target.attackPower.AddModifier(additivePower);
	}

}
```

## <a id="using-modifierlist" href="#using-modifierlist"> Using ModifierList </a>

If you want to modify the value without using ModifiableProperty, use a ModifierList.

```cs
ModifierList<int> m_DamageModifiers = new ModifierList<int>;

// Add something modifiers.
m_DamageModifiers.Add(modifier);

// Evaluate the damage.
int evaluatedDamage = m_DamageModifiers.Evaluate(damage);
```

ModifiableList is also used in the ModifiableProperty implementation.


# <a id="modifier-types" href="#modifier-types"> Modifier Types </a>

Basic operator modifiers are provided.

- Additive Modifier
- Subtractive Modifier
- Multiply Modifier
- Division Modifier

A variety of other unique modifiers are also available.

## <a id="set-modifier" href="#set-modifier"> Set Modifier </a>

The given value ignored and the specified value returned.

```cs
var setModifier = new SetModifierInt(0);

character.attackPower.AddModifier(setModifier);

// result is always 0.
int result = character.attackPower.Evaluate();
```

## <a id="create-modifier" href="#create-modifier"> Create Modifier </a>

The lambda formula allows you to improvise complex modifiers.

```cs
var createModifier = new CreateModifier<int>(value => {
	int result;

	// Do something process...

	return result;
});
```

# <a id="external-assets" href="#external-assets"> External Assets </a>

Modiferty supports integration with some external assets.

## <a id="unirx" href="#unirx"> UniRx </a>

Install UniRx and define `MODIFERTY_UNIRX` to enable integration with UniRx.

UniRx: [https://github.com/neuecc/UniRx](https://github.com/neuecc/UniRx)

The integration with UniRx mainly adds the following APIs to allow you to observe the values of Modiferty.

- `ReactiveModifierList<T>`
- `ReactiveModifiableProperty<T>`

```cs
using UnityEngine;
using UnityEngine.UI;
using MackySoft.Modiferty;
using UniRx;

public class Character : MonoBehaviour {

	// Define attackPower as ReactiveModifiableProperty.
	public ReactiveModifiableInt attackPower = new ReactiveModifiableInt(baseValue: 1);

	. . . . .

}

public class CharacterAttackPowerUI : MonoBehaviour {

	public Character character;
	public Text attackPowerTsxt;

	void Awake () {
		// You can observe changes BaseValue and Modifiers.
		character.attackPower.ObserveChanged().Subscribe(property => {

			// Apply the attackPower change to the text.
			attackPowerText.text = property.Evaluate();
		});
	}
}
```


# <a id="author-info" href="#author-info"> Author Info </a>

Hiroya Aramaki is a indie game developer in Japan.

- Blog: [https://mackysoft.net/blog](https://mackysoft.net/blog)
- Twitter: [https://twitter.com/makihiro_dev](https://twitter.com/makihiro_dev)

# <a id="license" href="#license"> License </a>

This library is under the MIT License.
