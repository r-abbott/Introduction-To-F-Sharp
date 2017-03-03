// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System

// Enum CarType
type CarType =
    | Tricar = 0
    | StandardFourWheeler = 1
    | HeavyLoadCarrier = 2
    | ReallyLargeTruck = 3
    | CrazyHugeMythicalMonster = 4
    | WeirdContraption = 5

// Class Car
//[<AbstractClass>] - if we did not have a default set for abstract methods/properties
type Car(color: string, wheelCount: int) = 
    // Guard Clauses
    do 
        if wheelCount < 3 then
            failwith "We'll assume that cars must have three wheels at least"
        if wheelCount > 99 then
            failwith "That's ridiculous"

    let carType = 
        match wheelCount with
        | 3 -> CarType.Tricar
        | 4 -> CarType.StandardFourWheeler
        | 6 -> CarType.HeavyLoadCarrier
        | x when x % 2 = 1 -> CarType.WeirdContraption
        | _ -> CarType.CrazyHugeMythicalMonster

    let mutable passengerCount = 0 // Mutable field

    new() = Car("red", 4) // Default Constructor

    // Function %A stands for Any
    member x.Move() = printfn "The %s car (%A) is moving" color carType
    // Property
    member x.CarType = carType

    abstract PassengerCount: int with get,set

    // get/set Property for mutable field
    default x.PassengerCount with get() = passengerCount and set v = passengerCount <- v

type Red18Wheeler() =
    inherit Car("red", 18)

    override x.PassengerCount
        with set v =
            if v > 2 then failwith "only two passengers allowed"
            else base.PassengerCount <- v

let truck = Red18Wheeler()

printfn "Truck has %d passengers on board" truck.PassengerCount
truck.PassengerCount <- 2
printfn "Truck has %d passengers on board" truck.PassengerCount

let truckObject = truck :> obj
let truckCar = truck :> Car

let truckObjectBackToCar = truckObject :?> Car


Console.ReadLine()

//[<EntryPoint>]
//let main argv = 
//    printfn "%A" argv
//    0 // return an integer exit code



