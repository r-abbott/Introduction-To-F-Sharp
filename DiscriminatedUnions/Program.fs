type MyEnum =
    | First = 0
    | Second = 1

type Product =
    | OwnProduct of string
    | SupplierReference of int

// Both are inferred as Product
let p1 = OwnProduct("bread")
let p2 = SupplierReference(53)

type Count = int

type StockBooking =
    | Incoming of Product * Count // tuple, needed since you can't do Product * int
    | Outgoing of Product * Count

let bookings = 
    [
        Incoming(OwnProduct("Rubber Chicken"), 50);
        Incoming(SupplierReference(112), 18);
        Outgoing(OwnProduct("Pulley"), 6);
        Outgoing(SupplierReference(37), 40);
    ]

// Extensions for discriminated union
type System.Int32 with
    member x.IsZero = x = 0

let i = 5
printfn "%A" i.IsZero

// Can also be used to extend discriminated union types
let booking = Incoming(SupplierReference(63), 20)

type StockBooking with
    member x.IsIncomingBooking() =
        match x with
        | Incoming(_,_) -> true
        | _ -> false

printfn "%A" (booking.IsIncomingBooking())

type 'a List = E | L of 'a * 'a List

let ints = L(10, L(12, L(15,E)))
printfn "%A" ints

let rec listSum = function
    | E -> 0
    | L(x, xs) -> x + (listSum xs)

printfn "%A" (listSum ints)