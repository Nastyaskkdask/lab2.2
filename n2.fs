open System


let generateRand (count: int) (minL: int) (maxL: int) =
    let rnd = new Random()
    [ for i in 1..count do
        let length = rnd.Next(minL, maxL + 1)
        let chars = 
            [ for j in 1..length do
                let index = rnd.Next(26)
                char (int 'a' + index) ]
        String(List.toArray chars) ]

let find (stringList: string list) =
    match stringList with
    | [] -> None
    | head :: tail ->
        let shortest =
            List.fold (fun (acc : string) (str : string) ->
                if str.Length < acc.Length then
                    str
                else
                    acc) head tail
        Some shortest




let count = 10 
let minL = 3 
let maxL = 10 

let random = generateRand count minL maxL

printfn "Сгенерированный список строк:"
random |> List.iter (printfn "%s")

match find random with
| Some shortestString -> printfn "\nСамая короткая строка: %s" shortestString
| None -> printfn "\nСписок пуст."
