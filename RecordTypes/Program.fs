// Record types are aggregate types
// Their members are immutable by default, but can be made mutable
// Instantiation works with the type inference from "record expressions"
// A special cloning syntax is available to create "modified clones" - the
// "copy and update record expression"
// There are no constructors
// Record types can have member methods and properties
// Match expressions can decompose record instances

// Rectangle type, declared with Width and Height
type Rectangle =
    { Width: float; Height: float}

// instantiated by matching expression from Rectangle {Width;Height}
let rect1 = {Width = 5.3; Height = 3.4}

type Circle =
    {Radius: float}
    // Adding member methods
    member x.RadiusSquare with get() = x.Radius * x.Radius
    member x.CalcArea() = System.Math.PI * x.RadiusSquare

// Again, instantiation by matching expression {Radius}
let c1 = {Radius = 3.3}

type Ellipse =
    { RadiusX: float; RadiusY: float}

    // Returning a new Ellipse that is "cloned" but with increased X/Y by delta
    member x.GrowX dx = { x with RadiusX = x.RadiusX + dx; }
    member x.GrowY dy = { x with RadiusY = x.RadiusY + dy; }

// Using the expression here matches to Circle, meaining only a Circle
// can be passed into this function
// if we needed to specify (say, more than one type has the Expression {Radius}
// we would need to use {Circle.Radius}
let zeroCircle = function
    | {Radius = 0.0 } -> true
    | _ -> false

printfn "%A" (zeroCircle c1)

// Similarly, only a rectangle can be passed into this function
let isSquare = function
    | { Width = width; Height = height } -> width = height

