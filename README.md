# Wscad.VectorGraphicViewer
```python
#Overview
Wscad.VectorGraphicViewer is a WPF application designed to visualize vector graphics. 
The application supports various shape types such as lines, circles, and triangles, and provides a flexible architecture for loading and displaying these shapes.

```

## Features

```python
•	Load and display vector shapes from data providers
•	Support for multiple shape types: Line, Circle, Triangle
•	Scalable shapes to fit within the canvas
•	MVVM architecture for separation of concerns
•	Unit tests for ViewModels and Data Providers

```


## Architecture

The application follows the MVVM (Model-View-ViewModel) pattern, ensuring a clear separation of concerns and facilitating testability.

```python
# Key Components
	•	ViewModels: Manage the state and behavior of the views
		•	MainViewModel: Manages the selected view model and commands
		•	VectorViewModel: Manages the collection of shapes and their loading
	•	Data Providers: Load shape data from various sources
		•	IVectorDataProvider: Interface for loading shapes
		•	VectorDataProvider: Implementation of IVectorDataProvider
	•	Shape Entities: Represent different types of shapes
		•	IShape: Interface for shape entities
		•	CircleData, TriangleData, LineData: Implementations of IShape
	•	Factories: Create shape instances from data
		•	IShapeFactory: Interface for shape factories
		•	ShapeFactory: Implementation of IShapeFactory
```

