module ListAndSequenceComprehensions

let output x = printfn "%A" x

let ints = [7..13] // list with values from 7 to 13, incluslively

let oddValues = [1..2..20] // all odd values up to 20

let values step max = [1..step..max] // function for 1 to max by step

printfn "%A" (values 2 20)

let ints' = seq {7..13} // constructing a sequence

// Only outputs a sequence
printfn "%A" ints'

printfn "%A" [ for x in 7..13 -> x * x] // get the squares from 7 to 13
// [49; 64; 81; 100; 121; 144; 169]
printfn "%A" [ for x in 7..13 -> x , x * x] // get the squares from 7 to 13 using tuple
// [(7, 49); (8, 64); (9, 81); (10, 100); (11, 121); (12, 144); (13, 169)]

printfn "%A" [ for x in 7..13 ->
                printfn "Return new value now"
                x , x * x] 
//Return new value now
//Return new value now
//Return new value now
//Return new value now
//Return new value now
//Return new value now
//Return new value now
//[(7, 49); (8, 64); (9, 81); (10, 100); (11, 121); (12, 144); (13, 169)]

// yielding sequence values
let yieldedValues =
    seq {
        yield 3; // value
        yield 42; // value
        for i in 1..3 do // yield for loop
            yield i
        yield! [5;7;8] // yield over list
    }

printfn "%A" (List.ofSeq yieldedValues) // List.ofSeq builds a new list from the given enumerable object

let yieldedStrings =
    seq {
        yield "this";
        yield "that";
    }

printfn "%A" yieldedStrings