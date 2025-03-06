open System

printf "Введите кол-во строк: "
let count = Console.ReadLine()
let check1 = 
    match System.Int32.TryParse(count) with
    | true, parsedInt -> parsedInt
    | false, _ -> 
        printfn "Ошибка: Введите целое число."
        exit 1 

let minL = 3 
let maxL = 7

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

let random = generateRand check1 minL maxL

printfn "Сгенерированный список строк:"
random |> List.iter (printfn "%s")

match find random with
| Some shortestString -> printfn "\nСамая короткая строка: %s" shortestString
| None -> printfn "Список пуст."

