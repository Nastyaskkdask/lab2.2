open System

let rnd = new Random()

let generateRandomString (minL: int) (maxL: int) =
    let length = rnd.Next(minL, maxL + 1)
    let chars = Array.zeroCreate length
    for i in 0..length - 1 do
        let charType = rnd.Next(3)
        chars[i] <-
            match charType with
            | 0 -> char (rnd.Next(10) + int '0')
            | 1 -> char (rnd.Next(26) + int 'a')
            | 2 -> char (rnd.Next(26) + int 'A')
            | _ -> ' '
    String chars

let generateRand (count: int) (minL: int) (maxL: int) =
    [ for i in 1..count do
          generateRandomString minL maxL ]

let find (stringList: string list) =
    match stringList with
    | [] -> None
    | head :: tail ->
        let shortest =
            List.fold (fun (acc : string) (str: string) ->
                if str.Length < acc.Length then
                    str
                else
                    acc) head tail
        Some shortest

printf "Выберите способ ввода списка строк (1 - рандомный, 2 - ручной): "
let inputMode = Console.ReadLine()

let myList = 
    match inputMode with
    | "1" ->
        printf "Введите кол-во строк: "
        let size = Console.ReadLine()
        match System.Int32.TryParse(size) with
        | true, parsedInt ->
            let minL = 1
            let maxL = 10
            generateRand parsedInt minL maxL
        | false, _ ->
            printfn "Ошибка: Введите целое число."
            exit 1
    | "2" ->
        printf "Введите строки (каждую на новой строке, пустая строка - конец ввода):\n"
        let rec readLines acc =
            match Console.ReadLine() with
            | line when String.IsNullOrEmpty(line) -> List.rev acc
            | line -> readLines (line :: acc)

        readLines [] 
    | _ ->
        printfn "Ошибка: Некорректный выбор режима ввода."
        exit 1


printfn "Сгенерированный список строк:"
myList |> List.iter (printfn "%s")

match find myList with
| Some shortestString -> printfn "\nСамая короткая строка: %s" shortestString
| None -> printfn "\nСписок пуст."

