open System
open System.Threading

// recursive function needs to be declared as "rec"
let rec fact x =
    if x = 1 then 1
    else x * (fact (x - 1))

printfn "%d" (fact 5)

// Recursive call between functions needs the "and" instruction
let rec fnA() = fnB()
and fnB() = fnA()

// recursively display random number every second, rather than using
// a while loop
let showValues() =
    let r = Random()
    let rec dl() =
        printfn "%d" (r.Next())
        Thread.Sleep(1000)
        dl()

    dl()

showValues()