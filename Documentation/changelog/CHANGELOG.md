# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.2] - 2021-05-16
### Added
- Added upm support.
- Added the `OperatorModifierInt`.
- Added the `OperatorModifierFloat`.
- Added the `ReactiveOperatorModifierInt`.
- Added the `ReactiveOperatorModifierFloat`.

## [1.1.1] - 2020-11-27
### Added
- Added unit tests.

### Changed
- UniRx Integration runtime code moved to `Runtime` folder.
- `ReactiveModifiableProperty<T>` / `ReactiveModifierList<T>`.`ObserveChanged` now observe `ReactiveModifierList<T>.ObserveMove`.

## [1.1.0] - 2020-11-27
### Added
- Added UniRx integration. (https://github.com/neuecc/UniRx)
    - Define `MODIFERTY_UNIRX` and enable it.
- Added `IModifierList<T>.AddModifierAsDisposable` extension method.

### Changed
- Renamed assembly name `MackySoft.Modiferty.Runtime` to `MackySoft.Modiferty`.
- `OperatorModifiers` now inherit from `ModifiableProperty`.
- The Modifier(s) suffix has been applied to the extension methods defined in `IModifiablePropertyExtensions`.
- `Multiply / DivisionModifierInt` now must specify the `RoundingMethod`.

## [1.0.3] - 2020-05-24
### Changed
- Changed type of multiply value of `MultiplyModifierInt` to float.
- Changed type of division value of `DivisionModifierInt` to float.

## [1.0.2] - 2020-05-23
### Added
- Added extension methods for `ModifierList`.

### Changed
- Renamed assembly `MackySoft.Modiferty` to `MackySoft.Modiferty.Runtime`.
- Renamed folder `Scripts` to `Runtime`.

## [1.0.1] - 2020-05-20
### Added
- Added `ModifierList` extension methods.
- Extracted the `IModifier` from `IModifier<T>`.

## [1.0.0] - 2020-05-19
First release