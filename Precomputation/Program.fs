open System.Collections.Generic

let isInList (list: 'a list) v =
    let lookupTable = new HashSet<'a>(list)
    printfn "Lookup table created, looking up value"
    lookupTable.Contains v

printfn "%b" (isInList["hi";"there";"oliver"] "there")
printfn "%b" (isInList["hi";"there";"oliver"] "anna")

// trying to create the list only once, but this does not work
// the list gets created each call
let isInListClever = isInList["hi";"there";"oliver"]
printfn "%b" (isInListClever "there")
printfn "%b" (isInListClever "anna")

// Instead, you can return a function for the lookup step
// leaving the construction of the list step to happen only once
let constructLookup (list: 'a list) =
    let lookupTable = new HashSet<'a>(list)
    printfn "Lookup table created"
    fun v ->
        printfn "Looking up value"
        lookupTable.Contains v

let isInListClever' = constructLookup ["hi";"there";"oliver"]
printfn "%b" (isInListClever' "there")
printfn "%b" (isInListClever' "anna")
