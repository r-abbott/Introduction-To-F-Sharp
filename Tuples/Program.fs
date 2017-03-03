let t1 = 12, 5, 7
let v1, v2, v3 = t1

let t2 = "hi", true

printfn "%A %A" (fst t2) (snd t2)

let third t =
    let _, _, r = t
    r
printfn "%A" (third t1)

// Pattern matching
let third' (_,_,r) = r
printfn "%A" (third' t1)