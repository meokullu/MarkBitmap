## MarkBitmap Changelog
[![MarkBitmap](https://img.shields.io/nuget/v/MarkBitmap.svg)](https://www.nuget.org/packages/MarkBitmap/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [1.0.0-alpha.6]

### Added
* `MarkHorizontalLine(byte[] buffer, int x, int y, int width, int length, Color color)` method added under BufferMarking.cs
* `MarkVerticalLine(byte[] buffer, int x, int y, int width, int length, Color color)` method added under BufferMarking.cs
* `MarkCorners(byte[] buffer, int width, int height, int length, Color color)` method added under BufferMarking.cs
* `MarkCorners(Bitmap bitmap, int length, Color color)` method is added.
* `MarkCameraGrid(Bitmap bitmap, Color color)` method is added

### Changed
* BitmapMarking.cs, BufferMarking.cs, Convertion.cs files are added. Related methods were moved into certain files.

### Removed
* `MarkWithCameraGrid(Bitmap bitmap)` method is removed. `MarkCameraGrid(Bitmap bitmap)` is alternative method.

### [1.0.0-alpha.5]

#### Added
* Multi-framework support for net7.0; net461; netstandard2.0

### [1.0.0-alpha.4]

#### Changed
* New design README.
* New design CHANGELOG.

### [1.0.0-alpha.3]

### Added
* `Image.GetPixelFormatSize()` added into `ToBuffer()` and not `depth` is used to create buffer.
* Method summaries.

### Changed
* Bug fixed on `Marshal.Copy()` on `ToBuffer()` which was causing data reading error.
* byte[] `MarkHorizontally()` method is fixed.
* byte[] `MarkVertically()` method is added and working.
* byte[] `MarkDiagonally()` method is added and not working.
* byte[] `MarkDiagonallyInverse` method is added and not working.

### Removed
* `MarkBuffer()` method is removed.
* `MarkBitmapInternal()` method is removed.

### [1.0.0-alpha.2]

#### Added
* Added CHANGELOG.
* Tag on PackageTags.

#### Changed
* Updated README
* Task List moved to Issues.

### [1.0.0-alpha.1]

#### Added
* Filling some method's summaries.
* Adding some comments.

#### Changed
* Using explicit variable instead of `var`.

### [1.0.0-alpha]
* Initial version.
