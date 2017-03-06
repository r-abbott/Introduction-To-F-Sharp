// Traditional functional languages often used their own built-in list types
// It's easy to build data handling functions on the basis of the F# List type,
// utilizing recursion
// Sequence fuctions are compatable with standard .NET IEnumerable<`T> patterns
// Again, easy to build your own using seq { ... }
// Most standard functions are available in the Seq module

type Product = { Name: string; Price: decimal }
type OrderLine = { Product: Product; Count: int }
type Order = { OrderId: string; Lines: OrderLine list }

let rubberChicken = { Name = "Rubber chicken"; Price = 8.99m }
let pulley = { Name = "Pulley"; Price = 1.95m }
let fairyDust = { Name = "Fairy Dust"; Price = 3.99m }
let foolsGold = { Name = "Fool's Gold"; Price = 14.98m }

let orders = [
    { OrderId = "O1"; 
        Lines = [{ Product = rubberChicken; Count = 18 };
                     { Product = pulley; Count = 20 }]};
    { OrderId = "O2"; 
        Lines = [{ Product = fairyDust; Count = 80 }]};
    { OrderId = "O3"; 
        Lines = [{ Product = foolsGold; Count = 33 };
                     { Product = fairyDust; Count = 33 }]};
    { OrderId = "O4"; 
        Lines = [{ Product = pulley; Count = 500 }]};
    { OrderId = "O5"; 
        Lines = [{ Product = rubberChicken; Count = 18 };
                     { Product = pulley; Count = 20 }]};
    { OrderId = "O6"; 
        Lines = [{ Product = foolsGold; Count = 100 };
                     { Product = fairyDust; Count = 100 };
                     { Product = pulley; Count = 100 };
                     { Product = rubberChicken; Count = 100 }]};
    { OrderId = "O7"; 
        Lines = [{ Product = fairyDust; Count = 160 }]};
    { OrderId = "O8"; 
        Lines = [{ Product = rubberChicken; Count = 18 };
                     { Product = pulley; Count = 20 }]};
    { OrderId = "O9"; 
        Lines = [{ Product = foolsGold; Count = 260 }]};
    { OrderId = "O10"; 
        Lines = [{ Product = pulley; Count = 80 }]};
]



let rec filterList filterFunc list = 
    match list with
    | [] -> list
    | x :: xs -> (if filterFunc x then [x] else []) @ (filterList filterFunc xs)

printfn "%A" (filterList (fun x -> x < 10) [1;3;17;20])

let rec mapList mapFunc list =
    match list with
    | [] -> []
    | x :: xs -> mapFunc x :: (mapList mapFunc xs)

printfn "%A" (mapList (fun x -> x * x) [1;5;10])

let rec foldList foldFunc startingValue list =
    match list with
    | [] -> startingValue
    | x :: xs -> foldList foldFunc (foldFunc startingValue x) xs

// + here is the same as declaring fun r v -> r + v
printfn "%A" (foldList (+) 0 [1;3;8])

let highValueOrders orders minValue =
    let linePrice l = decimal(l.Count) * l.Product.Price
    let orderPrice o = o.Lines |> mapList linePrice |> foldList (+) 0m

    orders |>
    mapList (fun o -> o.OrderId, orderPrice o) |>
    filterList (fun (_, price) -> price > minValue)

printfn "%A" (highValueOrders orders 250m)

// highValueOrders can be declared using built in functions
let highValueOrders' orders minValue =
    let linePrice l = decimal(l.Count) * l.Product.Price
    let orderPrice o = o.Lines |> List.map linePrice |> List.fold (+) 0m

    orders |>
    List.map (fun o -> o.OrderId, orderPrice o) |>
    List.filter (fun (_, price) -> price > minValue)

printfn "%A" (highValueOrders' orders 250m)

let filterSequence f s =
    seq {
        for i in s do
            if f i then yield i
    }

// using sequence type instead of list type
let highValueOrders'' orders minValue =
    let linePrice l = decimal(l.Count) * l.Product.Price
    let orderPrice o = o.Lines |> Seq.map linePrice |> Seq.fold (+) 0m

    orders |>
    Seq.map (fun o -> o.OrderId, orderPrice o) |>
    Seq.filter (fun (_, price) -> price > minValue)

printfn "%A" (highValueOrders'' orders 250m)
    