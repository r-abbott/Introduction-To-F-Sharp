// empty list will be generic
let empty = []

// integer list
let intList = [12;1;15;27]

printfn "%A" intList

// function to prepend list, uses :: operator
let addItem xs x = x :: xs
let newIntList = addItem intList 42
printfn "%A" newIntList

// append to list, use @ operator
printfn "%A" (["hi";"there"] @ ["how";"are";"you"])

printfn "%A" newIntList.Head // 42
printfn "%A" newIntList.Tail // [12;1;15;27]
printfn "%A" newIntList.Tail.Tail.Head // 1

// Iterating, like foreach in C#
for i in newIntList do
    printfn "%A" i

// Length by recursion
let rec listLength (l: 'a list) =
    if l.IsEmpty then 0
        else 1 + (listLength l.Tail)

printfn "%d" (listLength newIntList)

// pattern matching
// first check for empty list, return 0
// then split the head and tail and return 1 + tail length
let rec listLength' l =
    match l with
    | [] -> 0
    | _ :: xs -> 1 + (listLength' xs)

printfn "%d" (listLength' newIntList)

// Alternatively, can use the declarative function to omit the "match l with" piece
let rec listLength'' = function
    | [] -> 0
    | _ :: xs -> 1 + (listLength' xs)

printfn "%d" (listLength'' newIntList)

// Take n values from l List
let rec takeFromList n l =
    match n, l with
    | 0, _ -> []
    | _, [] -> []
    | _, (x :: xs) -> x :: (takeFromList (n - 1) xs)

printfn "%A" (takeFromList 2 newIntList)