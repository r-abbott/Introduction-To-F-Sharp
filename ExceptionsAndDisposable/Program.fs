// Exceptions

// Declaring an exception
exception MyCustomException of int * string
    with
        override x.Message =
            let (MyCustomException(i,s)) = upcast x
            sprintf "Int: %d Str: %s" i s

// Raise an exception
//raise (MyCustomException(10, "Error!"))

// Fail with message
//failwith "Some error occurred"

let rec fact x =
    if x < 0 then invalidArg "x" "Value must be >= 0"
    match x with
    | 0 -> 1
    | _ -> x * (fact (x - 1))

let output (o: obj) =
    try
        let os = o :?> string
        printfn "Object is %s" os
    with
    | :? System.InvalidCastException as ex -> printfn "Can't cast, message was: %s" ex.Message

//output 35

// try with as expression
let result =
    try
        Some(10 / 0)
    with
    | :? System.DivideByZeroException ->  None

printfn "%A" result

try
    raise (MyCustomException(3, "text"))
with
| MyCustomException(i, s) -> printfn "Caught custom exception with %d, %s" i s

let getValue() =
    try
        printfn "Returning Value"
        42
    finally
        printfn "In the finally block now"

getValue()

// IDisposable

let createDisposable f=
    { new System.IDisposable with member x.Dispose() = f()}

let outerFunction() =
    use disposable = createDisposable (fun() -> printfn "Now disposing myself")
    printfn "In outer function"

// Won't call Dispose when using "let disposable = ..."
// Will call Dispose when using "use disposable = ..." instead of let
outerFunction()

// using keyword example
let outerFunction'() =
    using (createDisposable( fun() -> printfn "Now disposing myself"))
        (fun d -> printfn "Acting on the disposable object now")
    printfn "In outer function"

outerFunction'()
