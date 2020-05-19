# Modifierty - Property Modification

**Created by Hiroya Aramaki ([Makihiro](https://twitter.com/makihiro_dev))**

## What is Modifiables ?

Modifiable is a great solution for making modifications to properties.

In games, there are often situations in which the status of characters, weapons, etc. temporarily change.

Modifiables can be used in the following situations.

- Want to modify the in-game character status temporally.

## <a id="index" href="#index"> Table of Contents </a>

- [Installation](#installation)
- [Usage](#usage)
  - [Using ModifierList](#using-modifierlist)
- [Modifier Types](#modifier-types)
	- [Set Modifier](#set-modifier)
	- [Create Modifier](#create-modifier)
- [Author Info](#author-info)
- [License](#license)

# <a id="installation" href="#installation"> Installation </a>

Download any version from releases.

Releases: https://github.com/mackysoft/Modiferty/releases

# <a id="usage" href="#requirements"> Usage </a>

Add "MackySoft.Modifiables" namespace into using area.

```cs
using MackySoft.Modifiables;
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

	public AdditiveModifier additiveDamage = new AdditiveModifier(1);

	public void Modify (Character target){
		target.attackPower.Modifiers.Add(additiveDamage);
		// target.attackPower.Add(additiveDamage);
		
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
var setModifier = new SetModifier(0);

character.attackPower.Add(setModifier);

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

# <a id="author-info" href="#author-info"> Author Info </a>

Hiroya Aramaki is a indie game developer in Japan.

- Blog: [https://mackysoft.net/blog](https://mackysoft.net/blog)
- Twitter: [https://twitter.com/makihiro_dev](https://twitter.com/makihiro_dev)

# <a id="license" href="#license"> License </a>

This library is under the MIT License.