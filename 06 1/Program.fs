open System
open System.IO

let rec distribute index value list =
    match Array.tryItem index list with
    | _ when value = 0 -> list
    | Some item ->
        let copy = Array.copy list
        Array.set copy index (item + 1)
        distribute (index + 1) (value - 1) copy
    | None -> distribute 0 value list

let minimize index elem maxIndex =
    if index = maxIndex
        then 1
        else elem

let rec rearange original list =
    let maxIndex = List.findIndex ((=) <| List.max list) list
    List.mapi (minimize maxIndex) list

[<EntryPoint>]
let main argv =
    let input =
        "./input.txt"
        |> File.ReadAllText
        |> (fun x -> x.Split [|'\t'|])

    printfn "%A" input
    0
