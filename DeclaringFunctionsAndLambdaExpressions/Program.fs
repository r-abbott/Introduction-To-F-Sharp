let add x y = x + y
let mult x y = x * y
let square x = x * x

// lambda
let add' = fun x y -> x + y
// partial application
let add'' x = fun y -> x + y

let add10'' = add'' 10
printfn "%d" (add10'' 32)

// another example of partial application
let addmultipleValues a b c d = a + b + c + d
let result = addmultipleValues 10
let result2 = result 15
let result3 = result2 20
printfn "%d" (result3 5)

let add10 = add 10
let mult5 = mult 5
let calcResult = mult5 (add10 17)
// piping/chaining operator |> passes result to next function
let calcResult' = 17 |> add10 |> mult5

// composition operator >> or << joins functions together
let add10mult5 = add10 >> mult5

let calcResult'' = add10mult5 17

printfn "%d %d" calcResult' calcResult''

// 'a is a generic type
let checkThis (item: 'c) (f: 'c -> bool) : unit =
    if f item then
        printfn "HIT"
    else
        printfn "MISS"


