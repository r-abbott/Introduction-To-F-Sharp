// Interface
type IMyInterface =
    abstract member Value: int with get

type IDerivedInterface =
    inherit IMyInterface

    abstract member Add: int -> int -> int

type MyClass() =
    interface IMyInterface with
        member x.Value with get() = 13

type MyOtherClass() =
    member this.Add x y = x + y

    interface IDerivedInterface with
        member i.Add x y = i.Add x y
        member x.Value = 42

let moc = MyOtherClass()

printfn "%A" (moc.Add 10 20)
// Have to upcast :> in order to use interface properties & methods
printfn "%A" ((moc :> IMyInterface).Value)
printfn "%A" ((moc :> IDerivedInterface).Add 12 30)

// Object Expressions
let hiObject = { new obj() with member x.ToString() = "Hi!" }

printfn "%A" hiObject

type IDeepThought =
    abstract member TheAnswer: int with get
    abstract member AnswerString: unit -> string

type DeepThought() =
    interface IDeepThought with
        member x.TheAnswer = 42
        member x.AnswerString() = sprintf "The answer is %d" (x :> IDeepThought).TheAnswer

let htmlDeepThought =
    let deepThought = DeepThought() :> IDeepThought
    // Creating the implementation of IDeepThought
    { new IDeepThought with
        member x.TheAnswer = deepThought.TheAnswer
        member x.AnswerString() = sprintf "<b>%s</b>" (deepThought.AnswerString())
    }

printfn "%A" (htmlDeepThought.AnswerString())
    
let confusedDeepThought answer =
    { new IDeepThought with
        member x.TheAnswer = answer
        member x.AnswerString() = "uh..." }

let cdt = confusedDeepThought 35
printfn "%A" cdt.TheAnswer
printfn "%A" (cdt.AnswerString())